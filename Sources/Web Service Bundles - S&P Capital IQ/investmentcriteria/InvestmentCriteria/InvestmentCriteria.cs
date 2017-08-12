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
[System.Web.Services.WebServiceBindingAttribute(Name="InvestmentCriteriaSoap", Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GeographiesOfInterest))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(StagesOfInterest))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(IndustriesOfInterest))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(CompanyBiteSize))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(InvestmentCriteriaDetail[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
public partial class InvestmentCriteria : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback GetInvestmentCriteriaOperationCompleted;
    
    /// <remarks/>
    public InvestmentCriteria() {
        this.Url = "https://api.capitaliq.com/ciqdotnet/api/current/InvestmentCriteria.asmx";
    }
    
    /// <remarks/>
    public event GetInvestmentCriteriaCompletedEventHandler GetInvestmentCriteriaCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://api.capitaliq.com/1.0/InvestmentCriteria/GetInvestmentCriteria", RequestNamespace="http://api.capitaliq.com/1.0/InvestmentCriteria", ResponseNamespace="http://api.capitaliq.com/1.0/InvestmentCriteria", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public InvestmentCriteriaDetail[] GetInvestmentCriteria(int[] CompanyId) {
        object[] results = this.Invoke("GetInvestmentCriteria", new object[] {
                    CompanyId});
        return ((InvestmentCriteriaDetail[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetInvestmentCriteria(int[] CompanyId, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetInvestmentCriteria", new object[] {
                    CompanyId}, callback, asyncState);
    }
    
    /// <remarks/>
    public InvestmentCriteriaDetail[] EndGetInvestmentCriteria(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((InvestmentCriteriaDetail[])(results[0]));
    }
    
    /// <remarks/>
    public void GetInvestmentCriteriaAsync(int[] CompanyId) {
        this.GetInvestmentCriteriaAsync(CompanyId, null);
    }
    
    /// <remarks/>
    public void GetInvestmentCriteriaAsync(int[] CompanyId, object userState) {
        if ((this.GetInvestmentCriteriaOperationCompleted == null)) {
            this.GetInvestmentCriteriaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetInvestmentCriteriaOperationCompleted);
        }
        this.InvokeAsync("GetInvestmentCriteria", new object[] {
                    CompanyId}, this.GetInvestmentCriteriaOperationCompleted, userState);
    }
    
    private void OnGetInvestmentCriteriaOperationCompleted(object arg) {
        if ((this.GetInvestmentCriteriaCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetInvestmentCriteriaCompleted(this, new GetInvestmentCriteriaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
public partial class InvestmentCriteriaDetail {
    
    private int companyIdField;
    
    private string companyNameField;
    
    private object[] industriesOfInterestField;
    
    private object[] geographiesOfInterestField;
    
    private object[] stagesOfInterestField;
    
    private object[] companyBiteSizeField;
    
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
    public string CompanyName {
        get {
            return this.companyNameField;
        }
        set {
            this.companyNameField = value;
        }
    }
    
    /// <remarks/>
    public object[] IndustriesOfInterest {
        get {
            return this.industriesOfInterestField;
        }
        set {
            this.industriesOfInterestField = value;
        }
    }
    
    /// <remarks/>
    public object[] GeographiesOfInterest {
        get {
            return this.geographiesOfInterestField;
        }
        set {
            this.geographiesOfInterestField = value;
        }
    }
    
    /// <remarks/>
    public object[] StagesOfInterest {
        get {
            return this.stagesOfInterestField;
        }
        set {
            this.stagesOfInterestField = value;
        }
    }
    
    /// <remarks/>
    public object[] CompanyBiteSize {
        get {
            return this.companyBiteSizeField;
        }
        set {
            this.companyBiteSizeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
public partial class GeographiesOfInterest {
    
    private string parentSubTypeIdField;
    
    private int subTypeIdField;
    
    private string subTypeNameField;
    
    /// <remarks/>
    public string ParentSubTypeId {
        get {
            return this.parentSubTypeIdField;
        }
        set {
            this.parentSubTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public int SubTypeId {
        get {
            return this.subTypeIdField;
        }
        set {
            this.subTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public string SubTypeName {
        get {
            return this.subTypeNameField;
        }
        set {
            this.subTypeNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
public partial class StagesOfInterest {
    
    private int subTypeIdField;
    
    private string subTypeNameField;
    
    /// <remarks/>
    public int SubTypeId {
        get {
            return this.subTypeIdField;
        }
        set {
            this.subTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public string SubTypeName {
        get {
            return this.subTypeNameField;
        }
        set {
            this.subTypeNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
public partial class IndustriesOfInterest {
    
    private string parentSubTypeIdField;
    
    private int subTypeIdField;
    
    private string subTypeNameField;
    
    /// <remarks/>
    public string ParentSubTypeId {
        get {
            return this.parentSubTypeIdField;
        }
        set {
            this.parentSubTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public int SubTypeId {
        get {
            return this.subTypeIdField;
        }
        set {
            this.subTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public string SubTypeName {
        get {
            return this.subTypeNameField;
        }
        set {
            this.subTypeNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://api.capitaliq.com/1.0/InvestmentCriteria")]
public partial class CompanyBiteSize {
    
    private int charTypeIdField;
    
    private string charTypeNameField;
    
    private string minValueField;
    
    private string maxValueField;
    
    /// <remarks/>
    public int CharTypeId {
        get {
            return this.charTypeIdField;
        }
        set {
            this.charTypeIdField = value;
        }
    }
    
    /// <remarks/>
    public string CharTypeName {
        get {
            return this.charTypeNameField;
        }
        set {
            this.charTypeNameField = value;
        }
    }
    
    /// <remarks/>
    public string MinValue {
        get {
            return this.minValueField;
        }
        set {
            this.minValueField = value;
        }
    }
    
    /// <remarks/>
    public string MaxValue {
        get {
            return this.maxValueField;
        }
        set {
            this.maxValueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void GetInvestmentCriteriaCompletedEventHandler(object sender, GetInvestmentCriteriaCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetInvestmentCriteriaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetInvestmentCriteriaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public InvestmentCriteriaDetail[] Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((InvestmentCriteriaDetail[])(this.results[0]));
        }
    }
}