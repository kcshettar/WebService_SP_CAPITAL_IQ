﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.42.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="CompanyResolutionSoap", Namespace="http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution")]
public partial class CompanyResolution : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback SearchCompaniesOperationCompleted;
    
    /// <remarks/>
    public CompanyResolution() {
        this.Url = "https://api.capitaliq.com/ciqdotnet/api/current/CompanyResolution.asmx";
    }
    
    /// <remarks/>
    public event SearchCompaniesCompletedEventHandler SearchCompaniesCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution/SearchCompanies", RequestNamespace="http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution", ResponseNamespace="http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public SearchCompanyInfo[] SearchCompanies(SearchCompanyCriterion[] inSearchCompanyCriterion, int inSearchTypeID) {
        object[] results = this.Invoke("SearchCompanies", new object[] {
                    inSearchCompanyCriterion,
                    inSearchTypeID});
        return ((SearchCompanyInfo[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSearchCompanies(SearchCompanyCriterion[] inSearchCompanyCriterion, int inSearchTypeID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SearchCompanies", new object[] {
                    inSearchCompanyCriterion,
                    inSearchTypeID}, callback, asyncState);
    }
    
    /// <remarks/>
    public SearchCompanyInfo[] EndSearchCompanies(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((SearchCompanyInfo[])(results[0]));
    }
    
    /// <remarks/>
    public void SearchCompaniesAsync(SearchCompanyCriterion[] inSearchCompanyCriterion, int inSearchTypeID) {
        this.SearchCompaniesAsync(inSearchCompanyCriterion, inSearchTypeID, null);
    }
    
    /// <remarks/>
    public void SearchCompaniesAsync(SearchCompanyCriterion[] inSearchCompanyCriterion, int inSearchTypeID, object userState) {
        if ((this.SearchCompaniesOperationCompleted == null)) {
            this.SearchCompaniesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchCompaniesOperationCompleted);
        }
        this.InvokeAsync("SearchCompanies", new object[] {
                    inSearchCompanyCriterion,
                    inSearchTypeID}, this.SearchCompaniesOperationCompleted, userState);
    }
    
    private void OnSearchCompaniesOperationCompleted(object arg) {
        if ((this.SearchCompaniesCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SearchCompaniesCompleted(this, new SearchCompaniesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution")]
public partial class SearchCompanyCriterion {
    
    private int searchIdentifierTypeIDField;
    
    private string searchTextField;
    
    private bool partialBooleanFlagField;
    
    /// <remarks/>
    public int SearchIdentifierTypeID {
        get {
            return this.searchIdentifierTypeIDField;
        }
        set {
            this.searchIdentifierTypeIDField = value;
        }
    }
    
    /// <remarks/>
    public string SearchText {
        get {
            return this.searchTextField;
        }
        set {
            this.searchTextField = value;
        }
    }
    
    /// <remarks/>
    public bool PartialBooleanFlag {
        get {
            return this.partialBooleanFlagField;
        }
        set {
            this.partialBooleanFlagField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.capitaliq.com/CIQDotNet/Company/CompanyResolution")]
public partial class SearchCompanyInfo {
    
    private int searchCompanyCriterionIndexField;
    
    private int searchCompanyResultTypeIDField;
    
    private int companyIDField;
    
    private string companyNameField;
    
    private string alternateCompanyNameField;
    
    private int primaryTradingItemIDField;
    
    private string securitySymbolField;
    
    private string tickerSymbolField;
    
    private int exchangeIDField;
    
    private int primaryIndustryIDField;
    
    private int ultimateParentCompanyIDField;
    
    private int companyTypeIDField;
    
    private int companyStatusTypeIDField;
    
    private bool hasResearchDocumentsFlagField;
    
    private bool hasEstimatesFlagField;
    
    private int templateTypeIDField;
    
    /// <remarks/>
    public int SearchCompanyCriterionIndex {
        get {
            return this.searchCompanyCriterionIndexField;
        }
        set {
            this.searchCompanyCriterionIndexField = value;
        }
    }
    
    /// <remarks/>
    public int SearchCompanyResultTypeID {
        get {
            return this.searchCompanyResultTypeIDField;
        }
        set {
            this.searchCompanyResultTypeIDField = value;
        }
    }
    
    /// <remarks/>
    public int CompanyID {
        get {
            return this.companyIDField;
        }
        set {
            this.companyIDField = value;
        }
    }
    
    /// <remarks/>
    public string CompanyName {
        get {
            return this.companyNameField;
        }
        set {
            this.companyNameField = value;
        }
    }
    
    /// <remarks/>
    public string AlternateCompanyName {
        get {
            return this.alternateCompanyNameField;
        }
        set {
            this.alternateCompanyNameField = value;
        }
    }
    
    /// <remarks/>
    public int PrimaryTradingItemID {
        get {
            return this.primaryTradingItemIDField;
        }
        set {
            this.primaryTradingItemIDField = value;
        }
    }
    
    /// <remarks/>
    public string SecuritySymbol {
        get {
            return this.securitySymbolField;
        }
        set {
            this.securitySymbolField = value;
        }
    }
    
    /// <remarks/>
    public string TickerSymbol {
        get {
            return this.tickerSymbolField;
        }
        set {
            this.tickerSymbolField = value;
        }
    }
    
    /// <remarks/>
    public int ExchangeID {
        get {
            return this.exchangeIDField;
        }
        set {
            this.exchangeIDField = value;
        }
    }
    
    /// <remarks/>
    public int PrimaryIndustryID {
        get {
            return this.primaryIndustryIDField;
        }
        set {
            this.primaryIndustryIDField = value;
        }
    }
    
    /// <remarks/>
    public int UltimateParentCompanyID {
        get {
            return this.ultimateParentCompanyIDField;
        }
        set {
            this.ultimateParentCompanyIDField = value;
        }
    }
    
    /// <remarks/>
    public int CompanyTypeID {
        get {
            return this.companyTypeIDField;
        }
        set {
            this.companyTypeIDField = value;
        }
    }
    
    /// <remarks/>
    public int CompanyStatusTypeID {
        get {
            return this.companyStatusTypeIDField;
        }
        set {
            this.companyStatusTypeIDField = value;
        }
    }
    
    /// <remarks/>
    public bool HasResearchDocumentsFlag {
        get {
            return this.hasResearchDocumentsFlagField;
        }
        set {
            this.hasResearchDocumentsFlagField = value;
        }
    }
    
    /// <remarks/>
    public bool HasEstimatesFlag {
        get {
            return this.hasEstimatesFlagField;
        }
        set {
            this.hasEstimatesFlagField = value;
        }
    }
    
    /// <remarks/>
    public int TemplateTypeID {
        get {
            return this.templateTypeIDField;
        }
        set {
            this.templateTypeIDField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void SearchCompaniesCompletedEventHandler(object sender, SearchCompaniesCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SearchCompaniesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal SearchCompaniesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public SearchCompanyInfo[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((SearchCompanyInfo[])(this.results[0]));
        }
    }
}
