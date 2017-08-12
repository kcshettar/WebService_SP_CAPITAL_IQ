Date - 08/08/2017
Project Name - Macquarie List Automation
Author - Shettar, Kiran <KShettar@navg.com>

Team:
Oskwarek, Noah <NOskwarek@navg.com>
Patel, Parimal <PPatel@navg.com>

Project Vision:
The goal of the Macquarie List Automation System is to prevent the burden of manually updating the incomplete data of the Macquarie list. 
The data extraction process can be automated by using API’s. Additionally, this prevents human error, provides the history of reports (Quarterly) with feedback 
and saves time. 

Project Names:
1. IntegrationServicesMacquarieAsset: (SSIS Package)
    - This is an Integration Services Project
    - This Project contains a Data Flow Task
    - The package will extract the values from column name 'Asset' & 'Address' from the source excel file
    - Sorts the values in Ascending order according to 'Asset'
    - Dumps the data into OLE DB Destination i.e. MacquarieData Database and assigns primary key to each Asset name

2. ConsoleApplicationAPIWebService:
    - This is a Console Application Project
    - This Application is built using C#
    - Refer Developer's Guide (SPCapitalIQAPIDevelopersGuide_v20046.pdf) before using source code
    - This makes requests to the API to get the data back from the S&P Capital IQ
    - The response data is stored into several objects. Clear the requests everytime in the source code to avoid duplicate requests to API
    - The source code has all the necessary comments to understand the process & code
    - There's option to access data with JSON format that is present in the current source code
    - A model view is created using the entity framework to access and store data to the Database
    - Calculate total number of requests: (Total Number of mnemonics * Total number of times invoked to data services)
    [Note: If a mnemonic gives back 'n' number of responses, it's still considered as one request E.g. List of Key Personnel in a company]
    - Request count & Execution time calculation logic has been already added in the source code. Refer the source code for more logics

3. MacquarieListReportProject:
    - This is a Reporting Services Project
    - This is designed according to the Business Analyst Requirements
    - Expressions are added in most of the fields as per the current requirements

Mnemonic & Data Guide:
1.  "IQ_COMPANY_ID_QUICK_MATCH" - Top 5 matches to the input string arranged by rank
2.  "IQ_PROFESSIONAL" - List of all professionals of company (Not in order) - Total Number of people: Maximum 30 
3.  "IQ_PROFESSIONAL_TITLE" - List of titles for respective company professionals - Manual code is written to display the CEO name at the first
4.  "IQ_COMPANY_CORP_TREE" - List of company ID's that come under the company tree. Companies with the filter "Current Subsidiary" are the priority
5.  "IQ_COMPANY_NAME" - Provides the name of the current company for the Company ID
6.  "IQ_ULT_PARENT" - Ultimate Parent name of the company
7.  "IQ_GVKEY" - Company GV_KEY used to get data for third party mnemonics
8.  "IQ_TOTAL_REV" - Total Revenue of the company in millions
9.  "IQ_BUSINESS_DESCRIPTION" - Business Description of the company
10. "IQ_COMPANY_WEBSITE" - Website link for the company
11. "IQ_COMPANY_TYPE" - Private/Public/Other
12. "IQ_YEAR_FOUNDED" - Year Found
13. "IQ_COMPANY_ADDRESS" - Company Headquarters Address
14. "IQ_COMPANY_PHONE" - Company Headquarters Telephone
15. "IQ_MARKETCAP" - Market capital of the company in millions
16. "IQ_PRIMARY_SIC_CODE" - Primary SIC Code (Multiple SIC codes cannot be accessed via API)
17. "IQ_PRIMARY_SIC_INDUSTRY" - Primary SIC Industry type
18. "IQ_COMPANY_TICKER" - Company Stock Symbol
19. "IQ_EMPLOYEES" - Global number of Employees (Latest) OR Total number of Employees
Mnemonics with dependency: 
20. "DUNS_ID" - Company DUNS number used to get company tax ID
21. "PRIM_NAICS_CD" - NAICS Code for company
22. "PRIM_NAICS_NAME" - NAICS Name for company 
23. "COMPANY_TAX_ID" - Also called as FEIN number OR Company Identification Number

Executing the Project:
Constraint: The table 'WebService2' has to be empty before running the SSIS package to prevent duplicate asset names
1. Run the SSIS Package : 
This loads data (Asset names) from the excel file and dumps data to the Database
2. Run the ConsoleApplicationAPIWebService project without Debugging
This executes by reading the Asset names row by row from the database. Requests data from the API. Dumps back the response data into database
3. Report Generation:
As the report is already deployed, just refresh the weblink to load the recent data from the database. [WebLink provided at the end of document]

Possible Exceptions: 
* All exceptions handled

To improve things:
* Handling Duplicates in the database
* QuickMatch Concept - Improving accuracy of the Asset name match. 
I've written a code that uses zipcode as a common filed to improve accuracy so far using regular expresion. 