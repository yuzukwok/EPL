//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace EnjoyPubLib.IPACS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Web.Services.WebServiceBindingAttribute(Name="Shlib_Mobile_WS_SolrSOAP", Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
    public partial class Shlib_Mobile_WS_Solr : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Mobile_iPacOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Shlib_Mobile_WS_Solr() {
			this.Url = "http://218.1.116.104:8080/axis2/services/Shlib_Mobile_WS_Solr";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Mobile_iPacCompletedEventHandler Mobile_iPacCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/Shlib_Mobile_WS_Solr/Mobile_iPac", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("Mobile_iPacResponse", Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
        public Mobile_iPacResponse Mobile_iPac([System.Xml.Serialization.XmlElementAttribute("Mobile_iPac", Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")] Mobile_iPac Mobile_iPac1) {
            object[] results = this.Invoke("Mobile_iPac", new object[] {
                        Mobile_iPac1});
            return ((Mobile_iPacResponse)(results[0]));
        }
        
        /// <remarks/>
        public void Mobile_iPacAsync(Mobile_iPac Mobile_iPac1) {
            this.Mobile_iPacAsync(Mobile_iPac1, null);
        }
        
        /// <remarks/>
        public void Mobile_iPacAsync(Mobile_iPac Mobile_iPac1, object userState) {
            if ((this.Mobile_iPacOperationCompleted == null)) {
                this.Mobile_iPacOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMobile_iPacOperationCompleted);
            }
            this.InvokeAsync("Mobile_iPac", new object[] {
                        Mobile_iPac1}, this.Mobile_iPacOperationCompleted, userState);
        }
        
        private void OnMobile_iPacOperationCompleted(object arg) {
            if ((this.Mobile_iPacCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Mobile_iPacCompleted(this, new Mobile_iPacCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
    public partial class Mobile_iPac {
        
        private Mobile_iPacType typeField;
        
        private string keyWordField;
        
        private string pageSizeField;
        
        private string startRowField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Mobile_iPacType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string KeyWord {
            get {
                return this.keyWordField;
            }
            set {
                this.keyWordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PageSize {
            get {
                return this.pageSizeField;
            }
            set {
                this.pageSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string StartRow {
            get {
                return this.startRowField;
            }
            set {
                this.startRowField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
    public enum Mobile_iPacType {
        
        /// <remarks/>
        author,
        
        /// <remarks/>
        title,
        
        /// <remarks/>
        ISBN,
        
        /// <remarks/>
        ISSN,
        
        /// <remarks/>
        subject,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
    public partial class Mobile_iPacResponse {
        
        private int pageSizeField;
        
        private int maxRowsField;
        
        private int currentRowField;
        
        private string queryStringField;
        
        private Mobile_iPacResponseBookItem[] bookItemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PageSize {
            get {
                return this.pageSizeField;
            }
            set {
                this.pageSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int MaxRows {
            get {
                return this.maxRowsField;
            }
            set {
                this.maxRowsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int CurrentRow {
            get {
                return this.currentRowField;
            }
            set {
                this.currentRowField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string QueryString {
            get {
                return this.queryStringField;
            }
            set {
                this.queryStringField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BookItem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Mobile_iPacResponseBookItem[] BookItem {
            get {
                return this.bookItemField;
            }
            set {
                this.bookItemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.example.org/Shlib_Mobile_WS_Solr/")]
    public partial class Mobile_iPacResponseBookItem {
        
        private string idField;
        
        private string titleField;
        
        private string callnoField;
        
        private string categoryField;
        
        private string contentField;
        
        private string isbnField;
        
        private string publisherField;
        
        private string authorField;
        
        private string placeField;
        
        private string dateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string callno {
            get {
                return this.callnoField;
            }
            set {
                this.callnoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string isbn {
            get {
                return this.isbnField;
            }
            set {
                this.isbnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string publisher {
            get {
                return this.publisherField;
            }
            set {
                this.publisherField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string place {
            get {
                return this.placeField;
            }
            set {
                this.placeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void Mobile_iPacCompletedEventHandler(object sender, Mobile_iPacCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Mobile_iPacCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Mobile_iPacCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Mobile_iPacResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Mobile_iPacResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591