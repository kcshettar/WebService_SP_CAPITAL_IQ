using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Connecting through SDK proxy
using SDKServices.Model;
// Other References
using System.Xml.Linq;
using SDKServices.ServicesImpl;
using SDKServices.Util;
// XML & IO Library
using System.Xml;
using System.IO;
// JSON Library
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
// Data Model - Connection to database
using ConsoleApplicationAPIWebService.Models;
using System.Text.RegularExpressions;

namespace ConsoleApplicationAPIWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Count total number of requests
            int reqsCount = 0;

            // Calculate Execution Time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Create Service
            SDKDataServicesWrapperImpl service = new SDKDataServicesWrapperImpl();

            // Create Data Request Container
            List<SDKDataRequest> reqs = new List<SDKDataRequest>();

            // Create Data Request
            SDKDataRequest req;

            // 'using' statement used so that it is disposed by default everytime
            using (MacquarieDataEntitiesWebService2 context = new MacquarieDataEntitiesWebService2())
            {                
                // Count total number of assets in database
                int count = context.WebService2.Count(total => total.Asset != null);
                Console.WriteLine("Total number of companies in the database: " + count);
                
                // Count the total subsidiaries for compelte code run
                //int countTotalSubsidiaries = 0;
                //int countAllCurrentSubsidiaries = 0;

                // Check - Is 'WebService2' in the database is 'empty'?
                if (count != 0)
                {
                    // Loop through assets in database
                    foreach(int rowID in context.WebService2.Select(x => x.id))
                    {
                        // All the current details in the database can be accessed in the field 'asset' in below line
                        WebService2 asset = context.WebService2.FirstOrDefault(x => x.id == rowID);
                        Console.WriteLine("Asset Name from database: " + asset.Asset);
                        Console.WriteLine("ID from the database: " + asset.id);

                        //Prevent Overlapping
                        reqs.Clear();

                        // MATCH the top 5 company names according to rank
                        req = new SDKDataRequest(SDKEnumerators.Functions.GDSHE.ToString(),
                            new List<string> { asset.Asset }, // company identifier formats: "IBM", "IQ290734", "IQ290734", "IQ4276947"
                            new List<string> {
                            "IQ_COMPANY_ID_QUICK_MATCH",
                            },
                            new Dictionary<string, string> {
                            { "startrank", "1" },
                            { "endrank", "5" }
                            }
                        );
                        // Add Data Request to Data Request Container
                        reqs.Add(req);

                        SDKDataInput dataInputQuickMatch = new SDKDataInput(
                            "Apiadmin@navg.com", // apiUser - required
                            "Navigators2API", // apiPass - required
                            true, // default is true
                            null, // null or SDKProxy
                            new List<SDKDataRequest>(reqs)
                        );

                        var respOBJECTQuickMatch = service.InvokeDataService(dataInputQuickMatch) as List<SDKDataOutput>;
                        //string responseQuickMatch = (string)service.InvokeDataService(dataInputQuickMatch, "JSON");
                        reqsCount++;

                        //respOBJECTQuickMatch[0].ResultData[2][0]
                        int countNumberOfRowsMatch = respOBJECTQuickMatch[0].NumberOfRows;
                        string quickmatchStringID = null;

                        string address = asset.AddressSource;
                        //string address = "270 Madison Avenue, Suite200, NewYork, NY10016-2546";

                        Regex regex = new Regex(@"(\d{5})");
                        Match zipSourceMatch = regex.Match(address);

                        if(zipSourceMatch.Success)
                            Console.WriteLine(zipSourceMatch.Groups[1].Value);

                        string zipSourceCompare = zipSourceMatch.Groups[1].Value;
                        //int flag = address.LastIndexOf(" ");
                        //int flag2 = address.Length - 1;

                        //char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                        //int zipCodeIndex = address.IndexOfAny(digits, flag);
                        //string zipCodeMatch = null;
                        //string zipCodeContains = address.Substring(zipCodeIndex, address.Length - zipCodeIndex);

                        //string breakStringLastPart = zipCodeContains.TrimStart(digits);
                        //string breakStringFirstPart = address.Substring(0, zipCodeIndex);
                        //string zipCodeToCompare = address.Substring(breakStringFirstPart.Length, address.Length - breakStringLastPart.Length - breakStringFirstPart.Length);

                        //Console.WriteLine("The zipcode to compare: " + zipCodeToCompare);

                        //if (zipCodeToCompare.Length < 5 || zipCodeToCompare.Length > 6)
                        //{
                        //    Console.WriteLine("No Zip Code found");
                        //}
                        //else
                        //{
                        //    zipCodeMatch = zipCodeToCompare;
                        //}

                        for (int FirstOrDefault = 0; FirstOrDefault<countNumberOfRowsMatch; FirstOrDefault++)
                        {
                            string zipCodeMatchCompanyID = respOBJECTQuickMatch[0].ResultData[FirstOrDefault][0];
                            Console.WriteLine("The company ID is: " + zipCodeMatchCompanyID);

                            reqs.Clear();
                            req = new SDKDataRequest(SDKEnumerators.Functions.GDSP.ToString(),
                                new List<string> { zipCodeMatchCompanyID },
                                new List<string> {
                                "IQ_COMPANY_ADDRESS", // headquarters address
                                },
                                new Dictionary<string, string> {
                                //{ "periodType", "IQ_FY" }, // returns total employees - current fiscal year (FY)
                                { "restatementTypeId", "LC" }, // latest on capital iq (LC)
                                }
                            );
                            // Add Data Request to Data Request Container
                            reqs.Add(req);

                            SDKDataInput dataInputzipCodeMatchCompanyID = new SDKDataInput(
                                "Apiadmin@navg.com", // apiUser - required
                                "Navigators2API", // apiPass - required
                                true, // default is true
                                null, // null or SDKProxy
                                new List<SDKDataRequest>(reqs)
                            );

                            var respOBJECTzipCodeMatchCompanyID = service.InvokeDataService(dataInputzipCodeMatchCompanyID) as List<SDKDataOutput>;
                            //string responsezipCodeMatchCompanyID = (string)service.InvokeDataService(dataInput1, "JSON");

                            string companyAddress = respOBJECTzipCodeMatchCompanyID[0].ResultData[0][0];
                            Console.WriteLine("To Compare" + companyAddress);
                            bool HitRate = companyAddress.Contains(zipSourceCompare);
                            
                            if (HitRate == true)
                            {
                                quickmatchStringID = zipCodeMatchCompanyID;
                                break;
                            }
                        }

                        /* Handle Max.Rquest limit reached exception; Change the comparison STRING */
                        if (respOBJECTQuickMatch[0].ResultData[0][0] != "Data Unavailable")
                        {
                            /* QuickMatch result assigned to a string */
                            //string quickmatchStringID = respOBJECTQuickMatch[0].ResultData[0][0];
                            Console.WriteLine("Company ID is: " + quickmatchStringID);
                            asset.QuickMatchID = quickmatchStringID;

                            /* KeyProfessionalDetails */
                            //req = new SDKDataRequest(SDKEnumerators.Functions.GDSHE.ToString(),
                            //    new List<string> { quickmatchStringID },
                            //    new List<string> {
                            //        "IQ_PROFESSIONAL", // list of all professionals of company
                            //        "IQ_PROFESSIONAL_TITLE", // title of respective company professionals
                            //    },
                            //    new Dictionary<string, string> {
                            //        { "startrank", "1" },
                            //        { "endrank", "30" },
                            //        { "metadatadtag", "Rank" }
                            //    }
                            //);
                            //// Add Data Request to Data Request Container
                            //reqs.Add(req);

                            //// Create Data Input
                            //SDKDataInput dataInputProfessional = new SDKDataInput(
                            //    "Apiadmin@navg.com", // apiUser - required
                            //    "Navigators2API", // apiPass - required
                            //    true, // default is true
                            //    null, // null or SDKProxy
                            //    new List<SDKDataRequest>(reqs)
                            //);

                            //var respOBJECTProfessional = service.InvokeDataService(dataInputProfessional) as List<SDKDataOutput>;
                            ////string responseProfessional = (string)service.InvokeDataService(dataInputProfessional, "JSON");
                            //reqsCount = reqsCount + 2;

                            //additional flower
                        }

                        //        /* KeyProfessionalDetails: CEO name is always displayed at the start
                        //         * Count total number of key personnel available 
                        //         */
                        //        int countRows = respOBJECTProfessional[1].NumberOfRows;
                        //        if (countRows >= 1)
                        //        {
                        //            int countKeyPersonnel = 0;
                        //            if (respOBJECTProfessional[1].ResultData[0][0] == "Data Unavailable")
                        //            {
                        //                Console.WriteLine("No Key Professional listed for the Company: " + quickmatchStringID);
                        //            }
                        //            else
                        //            {
                        //                string keyPersonnel = null;
                        //                string keyPersonnelTitle = null;
                        //                StringBuilder resultProfessional = new StringBuilder();

                        //                /* Looping through all the key Professional details 
                        //                 * Adds Key Professional details into StringBuilder object
                        //                 * Only the company CEO is added in the for loop below
                        //                 */
                        //                for (int i = 0; i < countRows; i++)
                        //                {
                        //                    for (int j = 0; j < 1; j++)
                        //                    {
                        //                        keyPersonnel = respOBJECTProfessional[1].ResultData[i][0];
                        //                        keyPersonnelTitle = respOBJECTProfessional[2].ResultData[i][0];
                        //                        string s1 = "CEO";
                        //                        bool starts = keyPersonnelTitle.StartsWith(s1);
                        //                        string s2 = "Chief Executive Officer,";
                        //                        bool compare = keyPersonnelTitle.Contains(s2);
                        //                        string s3 = "Chief Executive Officer";
                        //                        bool compareOther = keyPersonnelTitle.Contains(s3);
                        //                        if (starts == true || compare == true || compareOther == true)
                        //                        {
                        //                            countKeyPersonnel++;
                        //                            resultProfessional.Append(keyPersonnel + " - " + keyPersonnelTitle + " | ");
                        //                        }
                        //                    }
                        //                    string storeProfessionalDetailsCEO = resultProfessional.ToString();
                        //                }

                        //                /* Looping through all the key Professional details 
                        //                 * Adds Key Professional details into StringBuilder object
                        //                 * Rest of the Professional details, except CEO is added in the for loop below
                        //                 */
                        //                for (int i = 0; i < countRows; i++)
                        //                {
                        //                    for (int j = 0; j < 1; j++)
                        //                    {
                        //                        keyPersonnel = respOBJECTProfessional[1].ResultData[i][0];
                        //                        keyPersonnelTitle = respOBJECTProfessional[2].ResultData[i][0];
                        //                        string s1 = "CEO";
                        //                        bool starts = keyPersonnelTitle.StartsWith(s1);
                        //                        string s2 = "Chief Executive Officer,";
                        //                        bool compare = keyPersonnelTitle.Contains(s2);
                        //                        string s3 = "Chief Executive Officer";
                        //                        bool compareOther = keyPersonnelTitle.Contains(s3);
                        //                        if (starts != true && compare != true && compareOther != true)
                        //                        {
                        //                            countKeyPersonnel++;
                        //                            resultProfessional.Append(keyPersonnel + " - " + keyPersonnelTitle + " | ");
                        //                        }
                        //                    }
                        //                    string storeProfessionalDetailsCEO = resultProfessional.ToString();
                        //                }

                        //                // Final Professional Details being stored in a single string & then to the table in database 
                        //                string storeProfessionalDetailsOther = resultProfessional.ToString();
                        //                string finalProfessionalDetails = resultProfessional.ToString();
                        //                Console.WriteLine("Professional Details: " + finalProfessionalDetails);
                        //                Console.WriteLine("Total Key Personnel for the company: " + countKeyPersonnel);
                        //                asset.Key_Personnel = finalProfessionalDetails;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("Exception Handled for Key Professional; No Response");
                        //        }

                        //        // Search all the Current Subsidaries of a company */
                        //        req = new SDKDataRequest(SDKEnumerators.Functions.GDSPV.ToString(), //Alternate function name - GDSHV
                        //            new List<string> { quickmatchStringID },
                        //            new List<string> {
                        //                "IQ_COMPANY_CORP_TREE"
                        //            },
                        //            new Dictionary<string, string>()
                        //        );
                        //        // Add Data Request to Data Request Container
                        //        reqs.Add(req);

                        //        // Create Data Input
                        //        SDKDataInput dataInputSubsidiary = new SDKDataInput(
                        //            "Apiadmin@navg.com", // apiUser - required
                        //            "Navigators2API", // apiPass - required
                        //            true, // default is true
                        //            null, // null or SDKProxy
                        //            new List<SDKDataRequest>(reqs)
                        //        );

                        //        var respOBJECTSubsidiary = service.InvokeDataService(dataInputSubsidiary) as List<SDKDataOutput>;
                        //        //string responseSubsidiary = (string)service.InvokeDataService(dataInputSubsidiary, "JSON");
                        //        reqsCount++;

                        //        int countRowsSubsidiary = respOBJECTSubsidiary[3].NumberOfRows;
                        //        if (countRowsSubsidiary > 1)
                        //        {
                        //            reqs.Clear();
                        //            int countCompanyCorpTree = 0;
                        //            int countTotalCurrentSubsidiary = 0;
                        //            string subsidiaryListID = null;
                        //            //string subsidiaryListName = null;
                        //            StringBuilder resultID = new StringBuilder();
                        //            //StringBuilder resultName = new StringBuilder();
                        //            for (int i = 1; i < countRowsSubsidiary; i++)
                        //            {
                        //                reqs.Clear();
                        //                var match = respOBJECTSubsidiary[3].ResultData[i][2];
                        //                if (match != "CurrentSubsidiary")
                        //                {
                        //                    Console.WriteLine("This company is Not a CurrentSubsidiary");
                        //                    countCompanyCorpTree++;
                        //                }
                        //                else
                        //                {
                        //                    Console.WriteLine("Subsidiary Company ID: " + respOBJECTSubsidiary[3].ResultData[i][0]);
                        //                    subsidiaryListID = "IQ" + respOBJECTSubsidiary[3].ResultData[i][0];

                        //                    resultID.Append(subsidiaryListID + " | ");

                        //                    //// Create a request to get the company name of every subsidiary
                        //                    //req = new SDKDataRequest(SDKEnumerators.Functions.GDSHE.ToString(),
                        //                    //    new List<string> { subsidiaryListID },
                        //                    //    new List<string> {
                        //                    //    "IQ_COMPANY_NAME"
                        //                    //    },
                        //                    //    new Dictionary<string, string>()
                        //                    //);
                        //                    //// Add Data Request to Data Request Container
                        //                    //reqs.Add(req);
                        //                    //// Create Data Input
                        //                    //SDKDataInput dataInputSubsidiaryName = new SDKDataInput(
                        //                    //    "Apiadmin@navg.com", // apiUser - required
                        //                    //    "Navigators2API", // apiPass - required
                        //                    //    true, // default is true
                        //                    //    null, // null or SDKProxy
                        //                    //    new List<SDKDataRequest>(reqs)
                        //                    //);

                        //                    //var respOBJECTSubsidiaryName = service.InvokeDataService(dataInputSubsidiaryName) as List<SDKDataOutput>;
                        //                    ////string responseSubsidiaryName = (string)service.InvokeDataService(dataInputSubsidiaryName, "JSON");
                        //                    //reqsCount++;

                        //                    //subsidiaryListName = respOBJECTSubsidiaryName[0].ResultData[0][0];
                        //                    //resultName.Append(subsidiaryListName + " | ");
                        //                    countCompanyCorpTree++;
                        //                    countTotalCurrentSubsidiary++;
                        //                    countAllCurrentSubsidiaries++;
                        //                }
                        //                string storeSubsidiaryID = resultID.ToString();
                        //                //string storeSubsidiaryName = resultName.ToString();
                        //            }

                        //            // Final Subsidiary Details being stored in a single string & then to the table in database 
                        //            string finalSubsidiaryIDs = resultID.ToString();
                        //            //string finalSubsidiaryNames = resultName.ToString();
                        //            //Console.WriteLine("Subsidiary Details: " + finalSubsidiaryNames);
                        //            Console.WriteLine("Total Company Corporate Trees: " + countCompanyCorpTree);
                        //            Console.WriteLine("Total Current Subsidiaries: " + countTotalCurrentSubsidiary);
                        //            asset.SubsidiaryList = finalSubsidiaryIDs;
                        //            //asset.SubsidiaryList = finalSubsidiaryNames;
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("No Subsidiaries for the Company: " + quickmatchStringID);
                        //        }

                        //        reqs.Clear();
                        //        /* New request to compare between Parent company and Current company 
                        //         * Check if the current company is a subsidiary of any company or a parent itself
                        //         */
                        //        req = new SDKDataRequest(SDKEnumerators.Functions.GDSHE.ToString(),
                        //            new List<string> { quickmatchStringID },
                        //            new List<string> {
                        //            "IQ_ULT_PARENT", // ultimate parent
                        //            "IQ_COMPANY_NAME"
                        //            },
                        //            new Dictionary<string, string>()
                        //        );
                        //        // Add Data Request to Data Request Container
                        //        reqs.Add(req);
                        //        // Create Data Input
                        //        SDKDataInput dataInputMatch = new SDKDataInput(
                        //            "Apiadmin@navg.com", // apiUser - required
                        //            "Navigators2API", // apiPass - required
                        //            true, // default is true
                        //            null, // null or SDKProxy
                        //            new List<SDKDataRequest>(reqs)
                        //        );

                        //        var respOBJECTMatch = service.InvokeDataService(dataInputMatch) as List<SDKDataOutput>;
                        //        //string responseMatch = (string)service.InvokeDataService(dataInputMatch, "JSON");
                        //        reqsCount = reqsCount + 2;
                        //        asset.Parent_Company = respOBJECTMatch[0].ResultData[0][0];
                        //        asset.QuickMatchName = respOBJECTMatch[1].ResultData[0][0];

                        //        if (respOBJECTMatch[0].ResultData[0][0] == respOBJECTMatch[1].ResultData[0][0])
                        //        {
                        //            Console.WriteLine("The company name is: " + respOBJECTMatch[1].ResultData[0][0]);
                        //            Console.WriteLine("This is not a Subsiadary of any company");
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("The company name is: " + respOBJECTMatch[1].ResultData[0][0]);
                        //            Console.WriteLine("This is a Subsiadary of: " + respOBJECTMatch[0].ResultData[0][0]);
                        //        }

                        //        reqs.Clear();
                        //        // Getting the genral data for company
                        //        req = new SDKDataRequest(SDKEnumerators.Functions.GDSP.ToString(),
                        //            new List<string> { quickmatchStringID },
                        //            new List<string> {
                        //            "IQ_GVKEY", // key for reference - used in next calls 
                        //            "IQ_TOTAL_REV", // total revenue
                        //            "IQ_BUSINESS_DESCRIPTION", // business description of operations
                        //            "IQ_COMPANY_WEBSITE",// website
                        //            "IQ_COMPANY_TYPE", // private or public
                        //            "IQ_YEAR_FOUNDED", // year found
                        //            "IQ_COMPANY_ADDRESS", // headquarters address
                        //            "IQ_COMPANY_PHONE", // headquarters phone no
                        //            "IQ_MARKETCAP", // market cap in mm
                        //            "IQ_PRIMARY_SIC_CODE", // code number
                        //            "IQ_PRIMARY_SIC_INDUSTRY", // sic description or industry type
                        //            "IQ_COMPANY_TICKER", // stock symbol
                        //            },
                        //            new Dictionary<string, string> {
                        //            //{ "periodType", "IQ_FY" }, // returns total employees - current fiscal year (FY)
                        //            { "restatementTypeId", "LC" }, // latest on capital iq (LC)
                        //            }
                        //        );
                        //        // Add Data Request to Data Request Container
                        //        reqs.Add(req);

                        //        SDKDataInput dataInputGeneralDetails = new SDKDataInput(
                        //            "Apiadmin@navg.com", // apiUser - required
                        //            "Navigators2API", // apiPass - required
                        //            true, // default is true
                        //            null, // null or SDKProxy
                        //            new List<SDKDataRequest>(reqs)
                        //        );

                        //        var respOBJECTGeneralDetails = service.InvokeDataService(dataInputGeneralDetails) as List<SDKDataOutput>;
                        //        //string responseGeneralDetails = (string)service.InvokeDataService(dataInput1, "JSON");
                        //        reqsCount = reqsCount + 12;

                        //        if (respOBJECTGeneralDetails[1].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[1].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("TOTAL REVENUE: " + respOBJECTGeneralDetails[1].ResultData[0][0]);
                        //            asset.Total_Revenue = Convert.ToDecimal(respOBJECTGeneralDetails[1].ResultData[0][0]);
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("TOTAL REVENUE: " + respOBJECTGeneralDetails[1].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[2].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[2].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("BUSINESS DESCRIPTION: " + respOBJECTGeneralDetails[2].ResultData[0][0]);
                        //            asset.Business_Description = respOBJECTGeneralDetails[2].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("BUSINESS DESCRIPTION: " + respOBJECTGeneralDetails[2].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[3].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[3].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("COMPANY WEBSITE: " + respOBJECTGeneralDetails[3].ResultData[0][0]);
                        //            asset.Website = respOBJECTGeneralDetails[3].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("COMPANY WEBSITE: " + respOBJECTGeneralDetails[3].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[4].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[4].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("COMPANY TYPE: " + respOBJECTGeneralDetails[4].ResultData[0][0]);
                        //            asset.Company_Type = respOBJECTGeneralDetails[4].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("COMPANY TYPE: " + respOBJECTGeneralDetails[4].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[5].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[5].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("YEAR FOUND: " + respOBJECTGeneralDetails[5].ResultData[0][0]);
                        //            asset.Year_Found = Convert.ToInt32(respOBJECTGeneralDetails[5].ResultData[0][0]);
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("YEAR FOUND: " + respOBJECTGeneralDetails[5].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[6].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[6].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("COMPANY ADDRESS: " + respOBJECTGeneralDetails[6].ResultData[0][0]);
                        //            asset.HeadQuarters_Address = respOBJECTGeneralDetails[6].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("COMPANY ADDRESS: " + respOBJECTGeneralDetails[6].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[7].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[7].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("COMPANY TELEPHONE: " + respOBJECTGeneralDetails[7].ResultData[0][0]);
                        //            asset.Telephone_Number = respOBJECTGeneralDetails[7].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("COMPANY TELEPHONE: " + respOBJECTGeneralDetails[7].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[8].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[8].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("MARKET CAPITAL: " + respOBJECTGeneralDetails[8].ResultData[0][0]);
                        //            asset.Market_Cap = Convert.ToDecimal(respOBJECTGeneralDetails[8].ResultData[0][0]);
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("MARKET CAPITAL: " + respOBJECTGeneralDetails[8].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[9].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[9].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("SIC CODE: " + respOBJECTGeneralDetails[9].ResultData[0][0]);
                        //            asset.SIC_Code = Convert.ToInt32(respOBJECTGeneralDetails[9].ResultData[0][0]);
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("SIC CODE: " + respOBJECTGeneralDetails[9].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[10].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[10].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("SIC DESCRIPTION: " + respOBJECTGeneralDetails[10].ResultData[0][0]);
                        //            asset.SIC_Description = respOBJECTGeneralDetails[10].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("SIC DESCRIPTION: " + respOBJECTGeneralDetails[10].ResultData[0][0]);
                        //        }

                        //        if (respOBJECTGeneralDetails[11].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTGeneralDetails[11].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("STOCK SYMBOL: " + respOBJECTGeneralDetails[11].ResultData[0][0]);
                        //            asset.Stock_Symbol = respOBJECTGeneralDetails[11].ResultData[0][0];
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("STOCK SYMBOL: " + respOBJECTGeneralDetails[11].ResultData[0][0]);
                        //        }

                        //        /* Some companies have multiple GV_KEYS
                        //         * Handling multiple GV_KEY exception
                        //         * The first GV_KEY is selected by default in the code
                        //         */
                        //        string GV_KEY_CHECK = respOBJECTGeneralDetails[0].ResultData[0][0];
                        //        string CHECK = ",";
                        //        bool compareGVKEY = GV_KEY_CHECK.Contains(CHECK);
                        //        string GV_KEY = null;
                        //        if (compareGVKEY == true)
                        //        {
                        //            string flag = ",";
                        //            GV_KEY = GV_KEY_CHECK.Substring(0, GV_KEY_CHECK.IndexOf(flag));
                        //        }
                        //        else
                        //        {
                        //            GV_KEY = respOBJECTGeneralDetails[0].ResultData[0][0];
                        //        }

                        //        // GV_KEY is necessary to get the DUNS_ID & COMPANY_TAX_ID
                        //        Console.WriteLine("Original GV Key: " + GV_KEY);
                        //        if (GV_KEY != "Data Unavailable" && respOBJECTGeneralDetails[0].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            GV_KEY = GV_KEY.Replace("_", "");
                        //            Console.WriteLine("Modified GV Key: " + GV_KEY);

                        //            req = new SDKDataRequest(SDKEnumerators.Functions.GDSP.ToString(),
                        //                new List<string> { GV_KEY },
                        //                new List<string> {
                        //                "DUNS_ID", // duns id
                        //                "PRIM_NAICS_CD", // naics code
                        //                "PRIM_NAICS_NAME" // naics name
                        //                },
                        //                new Dictionary<string, string>()
                        //            );
                        //            // Add Data Request to Data Request Container
                        //            reqs.Add(req);

                        //            // Create Data Input
                        //            SDKDataInput dataInputThirdParty = new SDKDataInput(
                        //                "Apiadmin@navg.com", // apiUser - required
                        //                "Navigators2API", // apiPass - required
                        //                true, // default is true
                        //                null, // null or SDKProxy
                        //                new List<SDKDataRequest>(reqs)
                        //                );

                        //            var respOBJECTThirdParty = service.InvokeDataService(dataInputThirdParty) as List<SDKDataOutput>;
                        //            //string responseThirdParty = (string)service.InvokeDataService(dataInput2, "JSON");
                        //            reqsCount = reqsCount + 3;

                        //            if (respOBJECTThirdParty[12].ResultData[0][0] != "Data Unavailable" &&
                        //                respOBJECTThirdParty[12].ErrorMessage != "InvalidIdentifier")
                        //            {
                        //                Console.WriteLine("DUNS NUMBER: " + respOBJECTThirdParty[12].ResultData[0][0]);
                        //                asset.DUNS_Number = respOBJECTThirdParty[12].ResultData[0][0];
                        //            }
                        //            else
                        //            {
                        //                Console.WriteLine("DUNS NUMBER: " + respOBJECTThirdParty[12].ResultData[0][0]);
                        //            }

                        //            if (respOBJECTThirdParty[13].ResultData[0][0] != "Data Unavailable" &&
                        //                respOBJECTThirdParty[13].ErrorMessage != "InvalidIdentifier")
                        //            {
                        //                Console.WriteLine("NAICS CODE: " + respOBJECTThirdParty[13].ResultData[0][0]);
                        //                asset.NAICS_Code = Convert.ToInt32(respOBJECTThirdParty[13].ResultData[0][0]);
                        //            }
                        //            else
                        //            {
                        //                Console.WriteLine("NAICS CODE: " + respOBJECTThirdParty[13].ResultData[0][0]);
                        //            }

                        //            if (respOBJECTThirdParty[14].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTThirdParty[14].ErrorMessage != "InvalidIdentifier")
                        //            {
                        //                Console.WriteLine("NAICS DESCRIPTION: " + respOBJECTThirdParty[14].ResultData[0][0]);
                        //                asset.NAICS_Description = respOBJECTThirdParty[14].ResultData[0][0];
                        //            }
                        //            else
                        //            {
                        //                Console.WriteLine("NAICS DESCRIPTION: " + respOBJECTThirdParty[14].ResultData[0][0]);
                        //            }
                        //            Console.WriteLine("Original DUNS ID: " + respOBJECTThirdParty[12].ResultData[0][0]);
                        //            string DUNS_ID = respOBJECTThirdParty[12].ResultData[0][0];

                        //            /* DUNS_ID necessary to get COMPANY_TAX_ID */
                        //            if (DUNS_ID != "Data Unavailable")
                        //            {
                        //                DUNS_ID = ("DB" + DUNS_ID);
                        //                Console.WriteLine("Modified DUNS ID: " + DUNS_ID);

                        //                reqs.Clear();
                        //                req = new SDKDataRequest(SDKEnumerators.Functions.GDSP.ToString(),
                        //                    new List<string> { DUNS_ID },
                        //                    new List<string> {
                        //                    "COMPANY_TAX_ID"
                        //                    },
                        //                    new Dictionary<string, string>()
                        //                );
                        //                // Add Data Request to Data Request Container
                        //                reqs.Add(req);

                        //                // Create Data Input
                        //                SDKDataInput dataInputTaxID = new SDKDataInput(
                        //                    "Apiadmin@navg.com", // apiUser - required
                        //                    "Navigators2API", // apiPass - required
                        //                    true, // default is true
                        //                    null, // null or SDKProxy
                        //                    new List<SDKDataRequest>(reqs)
                        //                );

                        //                var respOBJECTTaxID = service.InvokeDataService(dataInputTaxID) as List<SDKDataOutput>;
                        //                //string responseTaxID = (string)service.InvokeDataService(dataInput3, "JSON");
                        //                reqsCount++;

                        //                string COMPANY_TAX_ID = respOBJECTTaxID[0].ResultData[0][0];
                        //                if (COMPANY_TAX_ID != "Data Unavailable" &&
                        //                    respOBJECTTaxID[0].ErrorMessage != "InvalidIdentifier")
                        //                {
                        //                    Console.WriteLine("GETTING COMPANY TAX ID: " + respOBJECTTaxID[0].ResultData[0][0]);
                        //                    asset.FEIN_Number = respOBJECTTaxID[0].ResultData[0][0];
                        //                }
                        //                else
                        //                {
                        //                    Console.WriteLine("COMPANY TAX ID: " + respOBJECTTaxID[0].ResultData[0][0]);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                Console.WriteLine("DUNS ID not available \nNAICS CODE not available \nNAICS NAME not available \nTAX ID not available");
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("DUNS ID not available \nNAICS CODE not available \nNAICS NAME not available \nTAX ID not available");
                        //        }

                        //        reqs.Clear();
                        //        req = new SDKDataRequest(SDKEnumerators.Functions.GDSHE.ToString(),
                        //            new List<string> { quickmatchStringID },
                        //            new List<string> {
                        //            "IQ_EMPLOYEES", // global Number of Employees (Latest) & total Number of Empployees
                        //            },
                        //            new Dictionary<string, string> {
                        //            { "periodType", "IQ_FY" }, // returns total employees - current fiscal year (FY)
                        //            { "restatementTypeId", "LC" }, // latest on capital iq (LC)
                        //            }
                        //        );
                        //        // Add Data Request to Data Request Container
                        //        reqs.Add(req);

                        //        // Create Data Input
                        //        SDKDataInput dataInputEmployeeCount = new SDKDataInput(
                        //            "Apiadmin@navg.com", // apiUser - required
                        //            "Navigators2API", // apiPass - required
                        //            true, // default is true
                        //            null, // null or SDKProxy
                        //            new List<SDKDataRequest>(reqs)
                        //        );

                        //        var respOBJECTEmployeeCount = service.InvokeDataService(dataInputEmployeeCount) as List<SDKDataOutput>;
                        //        //string responseFinal = (string)service.InvokeDataService(dataInputEmployeeCount, "JSON");
                        //        reqsCount++;

                        //        if (respOBJECTEmployeeCount[0].ResultData[0][0] != "Data Unavailable" &&
                        //            respOBJECTEmployeeCount[0].ErrorMessage != "InvalidIdentifier")
                        //        {
                        //            Console.WriteLine("TOTAL EMPLOYEES: " + respOBJECTEmployeeCount[0].ResultData[0][0]);
                        //            asset.Total_Employees = Convert.ToDouble(respOBJECTEmployeeCount[0].ResultData[0][0]);
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine("TOTAL EMPLOYEES: " + respOBJECTEmployeeCount[0].ResultData[0][0]);
                        //        }

                        //    // Clearing requests to avoid overlapping
                        //        reqs.Clear();
                        //    }
                        else
                        {
                            Console.WriteLine("No match found..!! Check the company name..");
                        }
                            //countTotalSubsidiaries = countTotalSubsidiaries + countAllCurrentSubsidiaries;
                        }
                        //Console.WriteLine("\nTotal Subsidiaries: " + countAllCurrentSubsidiaries);
                        context.SaveChanges();
                    }
                else
                {
                    Console.WriteLine("Table Name : WebService2 -> IsEmpty");
                }
            }
            
            // Calculating the execution time at the end
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total execution time (millisecond): " + elapsedMs);
            Console.WriteLine("Total execution time (seconds): " + elapsedMs/1000f);
            Console.WriteLine("Total execution time (minutes): " + (elapsedMs / 1000f)/60f);
            Console.WriteLine("Total ReqsCount: " + reqsCount);
            Console.Read();
        }
    }
}