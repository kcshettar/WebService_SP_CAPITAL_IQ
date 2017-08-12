﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
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
// This source code was auto-generated by wsdl, Version=2.0.50727.3038.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="FinancialDataSoap", Namespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData")]
public partial class FinancialData : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback GetFinancialsOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetFinTemplateDataItemsOperationCompleted;
    
    /// <remarks/>
    public FinancialData() {
        this.Url = "https://api.capitaliq.com/CIQDOTNET/api/current/FinancialData.asmx";
    }
    
    /// <remarks/>
    public event GetFinancialsCompletedEventHandler GetFinancialsCompleted;
    
    /// <remarks/>
    public event GetFinTemplateDataItemsCompletedEventHandler GetFinTemplateDataItemsCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Financials/FinancialData/GetFinancials", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public CompanyFinancials[] GetFinancials(int[] companyIdList, int[] dataItemList, int[] periodTypeIDList, short restatementTypeID, System.DateTime startPeriodDate, System.DateTime endPeriodDate, int currencyID, short currencyConversionMethod, int financialDataSetId) {
        object[] results = this.Invoke("GetFinancials", new object[] {
                    companyIdList,
                    dataItemList,
                    periodTypeIDList,
                    restatementTypeID,
                    startPeriodDate,
                    endPeriodDate,
                    currencyID,
                    currencyConversionMethod,
                    financialDataSetId});
        return ((CompanyFinancials[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFinancials(int[] companyIdList, int[] dataItemList, int[] periodTypeIDList, short restatementTypeID, System.DateTime startPeriodDate, System.DateTime endPeriodDate, int currencyID, short currencyConversionMethod, int financialDataSetId, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFinancials", new object[] {
                    companyIdList,
                    dataItemList,
                    periodTypeIDList,
                    restatementTypeID,
                    startPeriodDate,
                    endPeriodDate,
                    currencyID,
                    currencyConversionMethod,
                    financialDataSetId}, callback, asyncState);
    }
    
    /// <remarks/>
    public CompanyFinancials[] EndGetFinancials(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((CompanyFinancials[])(results[0]));
    }
    
    /// <remarks/>
    public void GetFinancialsAsync(int[] companyIdList, int[] dataItemList, int[] periodTypeIDList, short restatementTypeID, System.DateTime startPeriodDate, System.DateTime endPeriodDate, int currencyID, short currencyConversionMethod, int financialDataSetId) {
        this.GetFinancialsAsync(companyIdList, dataItemList, periodTypeIDList, restatementTypeID, startPeriodDate, endPeriodDate, currencyID, currencyConversionMethod, financialDataSetId, null);
    }
    
    /// <remarks/>
    public void GetFinancialsAsync(int[] companyIdList, int[] dataItemList, int[] periodTypeIDList, short restatementTypeID, System.DateTime startPeriodDate, System.DateTime endPeriodDate, int currencyID, short currencyConversionMethod, int financialDataSetId, object userState) {
        if ((this.GetFinancialsOperationCompleted == null)) {
            this.GetFinancialsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFinancialsOperationCompleted);
        }
        this.InvokeAsync("GetFinancials", new object[] {
                    companyIdList,
                    dataItemList,
                    periodTypeIDList,
                    restatementTypeID,
                    startPeriodDate,
                    endPeriodDate,
                    currencyID,
                    currencyConversionMethod,
                    financialDataSetId}, this.GetFinancialsOperationCompleted, userState);
    }
    
    private void OnGetFinancialsOperationCompleted(object arg) {
        if ((this.GetFinancialsCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetFinancialsCompleted(this, new GetFinancialsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Financials/FinancialData/GetFinTemplateDataIt" +
        "ems", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public FinancialDataItem[] GetFinTemplateDataItems(int templateTypeID, int financialDataSetId) {
        object[] results = this.Invoke("GetFinTemplateDataItems", new object[] {
                    templateTypeID,
                    financialDataSetId});
        return ((FinancialDataItem[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFinTemplateDataItems(int templateTypeID, int financialDataSetId, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFinTemplateDataItems", new object[] {
                    templateTypeID,
                    financialDataSetId}, callback, asyncState);
    }
    
    /// <remarks/>
    public FinancialDataItem[] EndGetFinTemplateDataItems(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((FinancialDataItem[])(results[0]));
    }
    
    /// <remarks/>
    public void GetFinTemplateDataItemsAsync(int templateTypeID, int financialDataSetId) {
        this.GetFinTemplateDataItemsAsync(templateTypeID, financialDataSetId, null);
    }
    
    /// <remarks/>
    public void GetFinTemplateDataItemsAsync(int templateTypeID, int financialDataSetId, object userState) {
        if ((this.GetFinTemplateDataItemsOperationCompleted == null)) {
            this.GetFinTemplateDataItemsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFinTemplateDataItemsOperationCompleted);
        }
        this.InvokeAsync("GetFinTemplateDataItems", new object[] {
                    templateTypeID,
                    financialDataSetId}, this.GetFinTemplateDataItemsOperationCompleted, userState);
    }
    
    private void OnGetFinTemplateDataItemsOperationCompleted(object arg) {
        if ((this.GetFinTemplateDataItemsCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetFinTemplateDataItemsCompleted(this, new GetFinTemplateDataItemsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData")]
public partial class CompanyFinancials {
    
    private int companyIdField;
    
    private int financialGroupIdField;
    
    private int templateTypeIdField;
    
    private FinancialInstanceInfo[] financialInstanceInfoListField;
    
    /// <remarks/>
    public int CompanyId {
        get {
            return this.companyIdField;
        }
        set {
            this.companyIdField = value;
        }
    }
    
    /// <remarks/>
    public int FinancialGroupId {
        get {
            return this.financialGroupIdField;
        }
        set {
            this.financialGroupIdField = value;
        }
    }
    
    /// <remarks/>
    public int TemplateTypeId {
        get {
            return this.templateTypeIdField;
        }
        set {
            this.templateTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public FinancialInstanceInfo[] FinancialInstanceInfoList {
        get {
            return this.financialInstanceInfoListField;
        }
        set {
            this.financialInstanceInfoListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData")]
public partial class FinancialInstanceInfo {
    
    private string financialInstanceIdField;
    
    private int periodTypeIdField;
    
    private int calendarYearField;
    
    private int calendarQuarterField;
    
    private short instanceTypeIdField;
    
    private short currencyConversionMethodField;
    
    private int currencyIdField;
    
    private int reportedCurrencyIdField;
    
    private int fiscalYearField;
    
    private short fiscalQuarterField;
    
    private System.DateTime pEODateField;
    
    private System.DateTime filingDateField;
    
    private int financialDataSetIdField;
    
    private FinancialDataPoint[] dataItemListField;
    
    /// <remarks/>
    public string FinancialInstanceId {
        get {
            return this.financialInstanceIdField;
        }
        set {
            this.financialInstanceIdField = value;
        }
    }
    
    /// <remarks/>
    public int PeriodTypeId {
        get {
            return this.periodTypeIdField;
        }
        set {
            this.periodTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public int CalendarYear {
        get {
            return this.calendarYearField;
        }
        set {
            this.calendarYearField = value;
        }
    }
    
    /// <remarks/>
    public int CalendarQuarter {
        get {
            return this.calendarQuarterField;
        }
        set {
            this.calendarQuarterField = value;
        }
    }
    
    /// <remarks/>
    public short InstanceTypeId {
        get {
            return this.instanceTypeIdField;
        }
        set {
            this.instanceTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public short CurrencyConversionMethod {
        get {
            return this.currencyConversionMethodField;
        }
        set {
            this.currencyConversionMethodField = value;
        }
    }
    
    /// <remarks/>
    public int CurrencyId {
        get {
            return this.currencyIdField;
        }
        set {
            this.currencyIdField = value;
        }
    }
    
    /// <remarks/>
    public int ReportedCurrencyId {
        get {
            return this.reportedCurrencyIdField;
        }
        set {
            this.reportedCurrencyIdField = value;
        }
    }
    
    /// <remarks/>
    public int FiscalYear {
        get {
            return this.fiscalYearField;
        }
        set {
            this.fiscalYearField = value;
        }
    }
    
    /// <remarks/>
    public short FiscalQuarter {
        get {
            return this.fiscalQuarterField;
        }
        set {
            this.fiscalQuarterField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime PEODate {
        get {
            return this.pEODateField;
        }
        set {
            this.pEODateField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime FilingDate {
        get {
            return this.filingDateField;
        }
        set {
            this.filingDateField = value;
        }
    }
    
    /// <remarks/>
    public int FinancialDataSetId {
        get {
            return this.financialDataSetIdField;
        }
        set {
            this.financialDataSetIdField = value;
        }
    }
    
    /// <remarks/>
    public FinancialDataPoint[] DataItemList {
        get {
            return this.dataItemListField;
        }
        set {
            this.dataItemListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData")]
public partial class FinancialDataPoint {
    
    private string dataItemValueField;
    
    private System.Nullable<short> scaleIdField;
    
    private short unitTypeIdField;
    
    private int dataItemIdField;
    
    private bool auditableFlagField;
    
    private bool subtotalField;
    
    private int orderField;
    
    private int financialDataSetIdField;
    
    /// <remarks/>
    public string DataItemValue {
        get {
            return this.dataItemValueField;
        }
        set {
            this.dataItemValueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public System.Nullable<short> ScaleId {
        get {
            return this.scaleIdField;
        }
        set {
            this.scaleIdField = value;
        }
    }
    
    /// <remarks/>
    public short UnitTypeId {
        get {
            return this.unitTypeIdField;
        }
        set {
            this.unitTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public int DataItemId {
        get {
            return this.dataItemIdField;
        }
        set {
            this.dataItemIdField = value;
        }
    }
    
    /// <remarks/>
    public bool AuditableFlag {
        get {
            return this.auditableFlagField;
        }
        set {
            this.auditableFlagField = value;
        }
    }
    
    /// <remarks/>
    public bool Subtotal {
        get {
            return this.subtotalField;
        }
        set {
            this.subtotalField = value;
        }
    }
    
    /// <remarks/>
    public int Order {
        get {
            return this.orderField;
        }
        set {
            this.orderField = value;
        }
    }
    
    /// <remarks/>
    public int FinancialDataSetId {
        get {
            return this.financialDataSetIdField;
        }
        set {
            this.financialDataSetIdField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.capitaliq.com/CIQDotNet/Financials/FinancialData")]
public partial class FinancialDataItem {
    
    private int dataItemIdField;
    
    private string dataItemNameField;
    
    /// <remarks/>
    public int DataItemId {
        get {
            return this.dataItemIdField;
        }
        set {
            this.dataItemIdField = value;
        }
    }
    
    /// <remarks/>
    public string DataItemName {
        get {
            return this.dataItemNameField;
        }
        set {
            this.dataItemNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
public delegate void GetFinancialsCompletedEventHandler(object sender, GetFinancialsCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetFinancialsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetFinancialsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public CompanyFinancials[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((CompanyFinancials[])(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
public delegate void GetFinTemplateDataItemsCompletedEventHandler(object sender, GetFinTemplateDataItemsCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetFinTemplateDataItemsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetFinTemplateDataItemsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public FinancialDataItem[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((FinancialDataItem[])(this.results[0]));
        }
    }
}
