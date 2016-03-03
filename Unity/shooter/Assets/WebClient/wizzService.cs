// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by Web Services Description Language Utility
//Mono Framework v4.0.30319.17020
//


/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IwizzService", Namespace="http://tempuri.org/")]
public partial class wizzService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback GetUserWebOperationCompleted;
    
    private System.Threading.SendOrPostCallback CreateUserOperationCompleted;
    
    private System.Threading.SendOrPostCallback ValidateUserOperationCompleted;
    
    /// CodeRemarks
    public wizzService() {
        this.Url = "http://178.157.216.170:8733/WCFwizzGames/";
    }
    
    /// CodeRemarks
    public event GetUserWebCompletedEventHandler GetUserWebCompleted;
    
    /// CodeRemarks
    public event CreateUserCompletedEventHandler CreateUserCompleted;
    
    /// CodeRemarks
    public event ValidateUserCompletedEventHandler ValidateUserCompleted;
    
    /// CodeRemarks
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IwizzService/GetUserWeb", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public User GetUserWeb([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string email) {
        object[] results = this.Invoke("GetUserWeb", new object[] {
                    email});
        return ((User)(results[0]));
    }
    
    /// CodeRemarks
    public void GetUserWebAsync(string email) {
        this.GetUserWebAsync(email, null);
    }
    
    /// CodeRemarks
    public void GetUserWebAsync(string email, object userState) {
        if ((this.GetUserWebOperationCompleted == null)) {
            this.GetUserWebOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserWebOperationCompleted);
        }
        this.InvokeAsync("GetUserWeb", new object[] {
                    email}, this.GetUserWebOperationCompleted, userState);
    }
    
    private void OnGetUserWebOperationCompleted(object arg) {
        if ((this.GetUserWebCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetUserWebCompleted(this, new GetUserWebCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// CodeRemarks
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IwizzService/CreateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public string CreateUser([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string name, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mail, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string password) {
        object[] results = this.Invoke("CreateUser", new object[] {
                    name,
                    mail,
                    password});
        return ((string)(results[0]));
    }
    
    /// CodeRemarks
    public void CreateUserAsync(string name, string mail, string password) {
        this.CreateUserAsync(name, mail, password, null);
    }
    
    /// CodeRemarks
    public void CreateUserAsync(string name, string mail, string password, object userState) {
        if ((this.CreateUserOperationCompleted == null)) {
            this.CreateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateUserOperationCompleted);
        }
        this.InvokeAsync("CreateUser", new object[] {
                    name,
                    mail,
                    password}, this.CreateUserOperationCompleted, userState);
    }
    
    private void OnCreateUserOperationCompleted(object arg) {
        if ((this.CreateUserCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.CreateUserCompleted(this, new CreateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// CodeRemarks
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IwizzService/ValidateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public string ValidateUser([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string mail, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string password) {
        object[] results = this.Invoke("ValidateUser", new object[] {
                    mail,
                    password});
        return ((string)(results[0]));
    }
    
    /// CodeRemarks
    public void ValidateUserAsync(string mail, string password) {
        this.ValidateUserAsync(mail, password, null);
    }
    
    /// CodeRemarks
    public void ValidateUserAsync(string mail, string password, object userState) {
        if ((this.ValidateUserOperationCompleted == null)) {
            this.ValidateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidateUserOperationCompleted);
        }
        this.InvokeAsync("ValidateUser", new object[] {
                    mail,
                    password}, this.ValidateUserOperationCompleted, userState);
    }
    
    private void OnValidateUserOperationCompleted(object arg) {
        if ((this.ValidateUserCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.ValidateUserCompleted(this, new ValidateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// CodeRemarks
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/wizzAppServer.DBmanager")]
public partial class User {
    
    private System.DateTime dateCreatedField;
    
    private bool dateCreatedFieldSpecified;
    
    private string emailField;
    
    private int idField;
    
    private bool idFieldSpecified;
    
    private string nameField;
    
    private string passwordField;
    
    /// <remarks/>
    public System.DateTime DateCreated {
        get {
            return this.dateCreatedField;
        }
        set {
            this.dateCreatedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DateCreatedSpecified {
        get {
            return this.dateCreatedFieldSpecified;
        }
        set {
            this.dateCreatedFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public string Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <remarks/>
    public int Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IdSpecified {
        get {
            return this.idFieldSpecified;
        }
        set {
            this.idFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
    public string Password {
        get {
            return this.passwordField;
        }
        set {
            this.passwordField = value;
        }
    }
}

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void GetUserWebCompletedEventHandler(object sender, GetUserWebCompletedEventArgs e);

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetUserWebCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetUserWebCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// CodeRemarks
    public User Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((User)(this.results[0]));
        }
    }
}

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void CreateUserCompletedEventHandler(object sender, CreateUserCompletedEventArgs e);

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CreateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal CreateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// CodeRemarks
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
public delegate void ValidateUserCompletedEventHandler(object sender, ValidateUserCompletedEventArgs e);

/// CodeRemarks
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ValidateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal ValidateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// CodeRemarks
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}
