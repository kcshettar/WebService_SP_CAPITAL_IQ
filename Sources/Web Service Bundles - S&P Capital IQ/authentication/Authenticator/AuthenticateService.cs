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
[System.Web.Services.WebServiceBindingAttribute(Name="AuthenticateServiceSoap", Namespace="https://www.capitaliq.com/CIQDotNet/Authenticator")]
public partial class AuthenticateService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback LoginOperationCompleted;
    
    private System.Threading.SendOrPostCallback EncryptedPasswordLoginOperationCompleted;
    
    private System.Threading.SendOrPostCallback EncryptedPasswordLoginWithExpenseCodeOperationCompleted;
    
    private System.Threading.SendOrPostCallback ExcelWebServiceAuthOperationCompleted;
    
    private System.Threading.SendOrPostCallback ExcelWebServiceAuthExpCodeOperationCompleted;
    
    private System.Threading.SendOrPostCallback UpdateExpenseCodeOperationCompleted;
    
    private System.Threading.SendOrPostCallback LogoutOperationCompleted;
    
    /// <remarks/>
    public AuthenticateService() {
        this.Url = "https://api.capitaliq.com/ciqdotnet/api/current/Authenticator.asmx";
    }
    
    /// <remarks/>
    public event LoginCompletedEventHandler LoginCompleted;
    
    /// <remarks/>
    public event EncryptedPasswordLoginCompletedEventHandler EncryptedPasswordLoginCompleted;
    
    /// <remarks/>
    public event EncryptedPasswordLoginWithExpenseCodeCompletedEventHandler EncryptedPasswordLoginWithExpenseCodeCompleted;
    
    /// <remarks/>
    public event ExcelWebServiceAuthCompletedEventHandler ExcelWebServiceAuthCompleted;
    
    /// <remarks/>
    public event ExcelWebServiceAuthExpCodeCompletedEventHandler ExcelWebServiceAuthExpCodeCompleted;
    
    /// <remarks/>
    public event UpdateExpenseCodeCompletedEventHandler UpdateExpenseCodeCompleted;
    
    /// <remarks/>
    public event LogoutCompletedEventHandler LogoutCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/Login", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public bool Login(string username, string password) {
        object[] results = this.Invoke("Login", new object[] {
                    username,
                    password});
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Login", new object[] {
                    username,
                    password}, callback, asyncState);
    }
    
    /// <remarks/>
    public bool EndLogin(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public void LoginAsync(string username, string password) {
        this.LoginAsync(username, password, null);
    }
    
    /// <remarks/>
    public void LoginAsync(string username, string password, object userState) {
        if ((this.LoginOperationCompleted == null)) {
            this.LoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginOperationCompleted);
        }
        this.InvokeAsync("Login", new object[] {
                    username,
                    password}, this.LoginOperationCompleted, userState);
    }
    
    private void OnLoginOperationCompleted(object arg) {
        if ((this.LoginCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.LoginCompleted(this, new LoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/EncryptedPasswordLogin", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public bool EncryptedPasswordLogin(string username, string password) {
        object[] results = this.Invoke("EncryptedPasswordLogin", new object[] {
                    username,
                    password});
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginEncryptedPasswordLogin(string username, string password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("EncryptedPasswordLogin", new object[] {
                    username,
                    password}, callback, asyncState);
    }
    
    /// <remarks/>
    public bool EndEncryptedPasswordLogin(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public void EncryptedPasswordLoginAsync(string username, string password) {
        this.EncryptedPasswordLoginAsync(username, password, null);
    }
    
    /// <remarks/>
    public void EncryptedPasswordLoginAsync(string username, string password, object userState) {
        if ((this.EncryptedPasswordLoginOperationCompleted == null)) {
            this.EncryptedPasswordLoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEncryptedPasswordLoginOperationCompleted);
        }
        this.InvokeAsync("EncryptedPasswordLogin", new object[] {
                    username,
                    password}, this.EncryptedPasswordLoginOperationCompleted, userState);
    }
    
    private void OnEncryptedPasswordLoginOperationCompleted(object arg) {
        if ((this.EncryptedPasswordLoginCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.EncryptedPasswordLoginCompleted(this, new EncryptedPasswordLoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/EncryptedPasswordLoginWithExpen" +
        "seCode", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public bool EncryptedPasswordLoginWithExpenseCode(string username, string password, string expenseCode) {
        object[] results = this.Invoke("EncryptedPasswordLoginWithExpenseCode", new object[] {
                    username,
                    password,
                    expenseCode});
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginEncryptedPasswordLoginWithExpenseCode(string username, string password, string expenseCode, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("EncryptedPasswordLoginWithExpenseCode", new object[] {
                    username,
                    password,
                    expenseCode}, callback, asyncState);
    }
    
    /// <remarks/>
    public bool EndEncryptedPasswordLoginWithExpenseCode(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public void EncryptedPasswordLoginWithExpenseCodeAsync(string username, string password, string expenseCode) {
        this.EncryptedPasswordLoginWithExpenseCodeAsync(username, password, expenseCode, null);
    }
    
    /// <remarks/>
    public void EncryptedPasswordLoginWithExpenseCodeAsync(string username, string password, string expenseCode, object userState) {
        if ((this.EncryptedPasswordLoginWithExpenseCodeOperationCompleted == null)) {
            this.EncryptedPasswordLoginWithExpenseCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEncryptedPasswordLoginWithExpenseCodeOperationCompleted);
        }
        this.InvokeAsync("EncryptedPasswordLoginWithExpenseCode", new object[] {
                    username,
                    password,
                    expenseCode}, this.EncryptedPasswordLoginWithExpenseCodeOperationCompleted, userState);
    }
    
    private void OnEncryptedPasswordLoginWithExpenseCodeOperationCompleted(object arg) {
        if ((this.EncryptedPasswordLoginWithExpenseCodeCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.EncryptedPasswordLoginWithExpenseCodeCompleted(this, new EncryptedPasswordLoginWithExpenseCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/ExcelWebServiceAuth", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public bool ExcelWebServiceAuth(string username, string password, string MACAddress) {
        object[] results = this.Invoke("ExcelWebServiceAuth", new object[] {
                    username,
                    password,
                    MACAddress});
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginExcelWebServiceAuth(string username, string password, string MACAddress, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("ExcelWebServiceAuth", new object[] {
                    username,
                    password,
                    MACAddress}, callback, asyncState);
    }
    
    /// <remarks/>
    public bool EndExcelWebServiceAuth(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public void ExcelWebServiceAuthAsync(string username, string password, string MACAddress) {
        this.ExcelWebServiceAuthAsync(username, password, MACAddress, null);
    }
    
    /// <remarks/>
    public void ExcelWebServiceAuthAsync(string username, string password, string MACAddress, object userState) {
        if ((this.ExcelWebServiceAuthOperationCompleted == null)) {
            this.ExcelWebServiceAuthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExcelWebServiceAuthOperationCompleted);
        }
        this.InvokeAsync("ExcelWebServiceAuth", new object[] {
                    username,
                    password,
                    MACAddress}, this.ExcelWebServiceAuthOperationCompleted, userState);
    }
    
    private void OnExcelWebServiceAuthOperationCompleted(object arg) {
        if ((this.ExcelWebServiceAuthCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.ExcelWebServiceAuthCompleted(this, new ExcelWebServiceAuthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/ExcelWebServiceAuthExpCode", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public bool ExcelWebServiceAuthExpCode(string username, string password, string MACAddress, string expenseCode) {
        object[] results = this.Invoke("ExcelWebServiceAuthExpCode", new object[] {
                    username,
                    password,
                    MACAddress,
                    expenseCode});
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginExcelWebServiceAuthExpCode(string username, string password, string MACAddress, string expenseCode, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("ExcelWebServiceAuthExpCode", new object[] {
                    username,
                    password,
                    MACAddress,
                    expenseCode}, callback, asyncState);
    }
    
    /// <remarks/>
    public bool EndExcelWebServiceAuthExpCode(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((bool)(results[0]));
    }
    
    /// <remarks/>
    public void ExcelWebServiceAuthExpCodeAsync(string username, string password, string MACAddress, string expenseCode) {
        this.ExcelWebServiceAuthExpCodeAsync(username, password, MACAddress, expenseCode, null);
    }
    
    /// <remarks/>
    public void ExcelWebServiceAuthExpCodeAsync(string username, string password, string MACAddress, string expenseCode, object userState) {
        if ((this.ExcelWebServiceAuthExpCodeOperationCompleted == null)) {
            this.ExcelWebServiceAuthExpCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExcelWebServiceAuthExpCodeOperationCompleted);
        }
        this.InvokeAsync("ExcelWebServiceAuthExpCode", new object[] {
                    username,
                    password,
                    MACAddress,
                    expenseCode}, this.ExcelWebServiceAuthExpCodeOperationCompleted, userState);
    }
    
    private void OnExcelWebServiceAuthExpCodeOperationCompleted(object arg) {
        if ((this.ExcelWebServiceAuthExpCodeCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.ExcelWebServiceAuthExpCodeCompleted(this, new ExcelWebServiceAuthExpCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/UpdateExpenseCode", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void UpdateExpenseCode(string expenseCode) {
        this.Invoke("UpdateExpenseCode", new object[] {
                    expenseCode});
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginUpdateExpenseCode(string expenseCode, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("UpdateExpenseCode", new object[] {
                    expenseCode}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndUpdateExpenseCode(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    public void UpdateExpenseCodeAsync(string expenseCode) {
        this.UpdateExpenseCodeAsync(expenseCode, null);
    }
    
    /// <remarks/>
    public void UpdateExpenseCodeAsync(string expenseCode, object userState) {
        if ((this.UpdateExpenseCodeOperationCompleted == null)) {
            this.UpdateExpenseCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateExpenseCodeOperationCompleted);
        }
        this.InvokeAsync("UpdateExpenseCode", new object[] {
                    expenseCode}, this.UpdateExpenseCodeOperationCompleted, userState);
    }
    
    private void OnUpdateExpenseCodeOperationCompleted(object arg) {
        if ((this.UpdateExpenseCodeCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.UpdateExpenseCodeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://www.capitaliq.com/CIQDotNet/Authenticator/Logout", RequestNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", ResponseNamespace="https://www.capitaliq.com/CIQDotNet/Authenticator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void Logout() {
        this.Invoke("Logout", new object[0]);
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginLogout(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Logout", new object[0], callback, asyncState);
    }
    
    /// <remarks/>
    public void EndLogout(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    public void LogoutAsync() {
        this.LogoutAsync(null);
    }
    
    /// <remarks/>
    public void LogoutAsync(object userState) {
        if ((this.LogoutOperationCompleted == null)) {
            this.LogoutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogoutOperationCompleted);
        }
        this.InvokeAsync("Logout", new object[0], this.LogoutOperationCompleted, userState);
    }
    
    private void OnLogoutOperationCompleted(object arg) {
        if ((this.LogoutCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.LogoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void LoginCompletedEventHandler(object sender, LoginCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public bool Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((bool)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void EncryptedPasswordLoginCompletedEventHandler(object sender, EncryptedPasswordLoginCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class EncryptedPasswordLoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal EncryptedPasswordLoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public bool Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((bool)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void EncryptedPasswordLoginWithExpenseCodeCompletedEventHandler(object sender, EncryptedPasswordLoginWithExpenseCodeCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class EncryptedPasswordLoginWithExpenseCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal EncryptedPasswordLoginWithExpenseCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public bool Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((bool)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void ExcelWebServiceAuthCompletedEventHandler(object sender, ExcelWebServiceAuthCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ExcelWebServiceAuthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal ExcelWebServiceAuthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public bool Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((bool)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void ExcelWebServiceAuthExpCodeCompletedEventHandler(object sender, ExcelWebServiceAuthExpCodeCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ExcelWebServiceAuthExpCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal ExcelWebServiceAuthExpCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public bool Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((bool)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void UpdateExpenseCodeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
public delegate void LogoutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
