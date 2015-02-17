// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Epl.IOS.n218_1_116_104 {
    
    
    /// <remarks/>
    [System.Web.Services.WebServiceBinding(Name="LibMobWS_DouBanSOAP", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LibMobWS_DouBan : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetBookInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBookCoverOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBookRatesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBookTagsOperationCompleted;
        
        private System.Threading.SendOrPostCallback iPACOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCommentsOperationCompleted;
        
        public LibMobWS_DouBan() {
			this.Url = "http://218.1.116.104:8080/axis2/services/LibMobWS_DouBan/";
        }
        
        public LibMobWS_DouBan(string url) {
            this.Url = url;
        }
        
        public event GetBookInfoCompletedEventHandler GetBookInfoCompleted;
        
        public event GetBookCoverCompletedEventHandler GetBookCoverCompleted;
        
        public event GetBookRatesCompletedEventHandler GetBookRatesCompleted;
        
        public event GetBookTagsCompletedEventHandler GetBookTagsCompleted;
        
        public event iPACCompletedEventHandler iPACCompleted;
        
        public event GetCommentsCompletedEventHandler GetCommentsCompleted;
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/GetBookInfo", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetBookInfoResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetBookInfoResponse GetBookInfo([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageGetBookInfo GetBookInfo) {
            object[] results = this.Invoke("GetBookInfo", new object[] {
                        GetBookInfo});
            return ((MessageGetBookInfoResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginGetBookInfo(MessageGetBookInfo GetBookInfo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetBookInfo", new object[] {
                        GetBookInfo}, callback, asyncState);
        }
        
        public MessageGetBookInfoResponse EndGetBookInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageGetBookInfoResponse)(results[0]));
        }
        
        public void GetBookInfoAsync(MessageGetBookInfo GetBookInfo) {
            this.GetBookInfoAsync(GetBookInfo, null);
        }
        
        public void GetBookInfoAsync(MessageGetBookInfo GetBookInfo, object userState) {
            if ((this.GetBookInfoOperationCompleted == null)) {
                this.GetBookInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookInfoCompleted);
            }
            this.InvokeAsync("GetBookInfo", new object[] {
                        GetBookInfo}, this.GetBookInfoOperationCompleted, userState);
        }
        
        private void OnGetBookInfoCompleted(object arg) {
            if ((this.GetBookInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBookInfoCompleted(this, new GetBookInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/GetBookCover", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetBookCoverResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetBookCoverResponse GetBookCover([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageGetBookCover GetBookCover) {
            object[] results = this.Invoke("GetBookCover", new object[] {
                        GetBookCover});
            return ((MessageGetBookCoverResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginGetBookCover(MessageGetBookCover GetBookCover, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetBookCover", new object[] {
                        GetBookCover}, callback, asyncState);
        }
        
        public MessageGetBookCoverResponse EndGetBookCover(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageGetBookCoverResponse)(results[0]));
        }
        
        public void GetBookCoverAsync(MessageGetBookCover GetBookCover) {
            this.GetBookCoverAsync(GetBookCover, null);
        }
        
        public void GetBookCoverAsync(MessageGetBookCover GetBookCover, object userState) {
            if ((this.GetBookCoverOperationCompleted == null)) {
                this.GetBookCoverOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookCoverCompleted);
            }
            this.InvokeAsync("GetBookCover", new object[] {
                        GetBookCover}, this.GetBookCoverOperationCompleted, userState);
        }
        
        private void OnGetBookCoverCompleted(object arg) {
            if ((this.GetBookCoverCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBookCoverCompleted(this, new GetBookCoverCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/GetBookRates", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetBookRatesResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetBookRatesResponse GetBookRates([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageGetBookRates GetBookRates) {
            object[] results = this.Invoke("GetBookRates", new object[] {
                        GetBookRates});
            return ((MessageGetBookRatesResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginGetBookRates(MessageGetBookRates GetBookRates, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetBookRates", new object[] {
                        GetBookRates}, callback, asyncState);
        }
        
        public MessageGetBookRatesResponse EndGetBookRates(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageGetBookRatesResponse)(results[0]));
        }
        
        public void GetBookRatesAsync(MessageGetBookRates GetBookRates) {
            this.GetBookRatesAsync(GetBookRates, null);
        }
        
        public void GetBookRatesAsync(MessageGetBookRates GetBookRates, object userState) {
            if ((this.GetBookRatesOperationCompleted == null)) {
                this.GetBookRatesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookRatesCompleted);
            }
            this.InvokeAsync("GetBookRates", new object[] {
                        GetBookRates}, this.GetBookRatesOperationCompleted, userState);
        }
        
        private void OnGetBookRatesCompleted(object arg) {
            if ((this.GetBookRatesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBookRatesCompleted(this, new GetBookRatesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/GetBookTags", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetBookTagsResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetBookTagsResponse GetBookTags([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageGetBookTags GetBookTags) {
            object[] results = this.Invoke("GetBookTags", new object[] {
                        GetBookTags});
            return ((MessageGetBookTagsResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginGetBookTags(MessageGetBookTags GetBookTags, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetBookTags", new object[] {
                        GetBookTags}, callback, asyncState);
        }
        
        public MessageGetBookTagsResponse EndGetBookTags(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageGetBookTagsResponse)(results[0]));
        }
        
        public void GetBookTagsAsync(MessageGetBookTags GetBookTags) {
            this.GetBookTagsAsync(GetBookTags, null);
        }
        
        public void GetBookTagsAsync(MessageGetBookTags GetBookTags, object userState) {
            if ((this.GetBookTagsOperationCompleted == null)) {
                this.GetBookTagsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookTagsCompleted);
            }
            this.InvokeAsync("GetBookTags", new object[] {
                        GetBookTags}, this.GetBookTagsOperationCompleted, userState);
        }
        
        private void OnGetBookTagsCompleted(object arg) {
            if ((this.GetBookTagsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBookTagsCompleted(this, new GetBookTagsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/iPAC", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("iPACResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageIPACResponse iPAC([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageIPAC iPAC) {
            object[] results = this.Invoke("iPAC", new object[] {
                        iPAC});
            return ((MessageIPACResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginiPAC(MessageIPAC iPAC, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("iPAC", new object[] {
                        iPAC}, callback, asyncState);
        }
        
        public MessageIPACResponse EndiPAC(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageIPACResponse)(results[0]));
        }
        
        public void iPACAsync(MessageIPAC iPAC) {
            this.iPACAsync(iPAC, null);
        }
        
        public void iPACAsync(MessageIPAC iPAC, object userState) {
            if ((this.iPACOperationCompleted == null)) {
                this.iPACOperationCompleted = new System.Threading.SendOrPostCallback(this.OniPACCompleted);
            }
            this.InvokeAsync("iPAC", new object[] {
                        iPAC}, this.iPACOperationCompleted, userState);
        }
        
        private void OniPACCompleted(object arg) {
            if ((this.iPACCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.iPACCompleted(this, new iPACCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.example.org/LibMobWS_DouBan/GetComments", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetCommentsResponse", Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetCommentsResponse GetComments([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] MessageGetComments GetComments) {
            object[] results = this.Invoke("GetComments", new object[] {
                        GetComments});
            return ((MessageGetCommentsResponse)(results[0]));
        }
        
        public System.IAsyncResult BeginGetComments(MessageGetComments GetComments, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetComments", new object[] {
                        GetComments}, callback, asyncState);
        }
        
        public MessageGetCommentsResponse EndGetComments(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((MessageGetCommentsResponse)(results[0]));
        }
        
        public void GetCommentsAsync(MessageGetComments GetComments) {
            this.GetCommentsAsync(GetComments, null);
        }
        
        public void GetCommentsAsync(MessageGetComments GetComments, object userState) {
            if ((this.GetCommentsOperationCompleted == null)) {
                this.GetCommentsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCommentsCompleted);
            }
            this.InvokeAsync("GetComments", new object[] {
                        GetComments}, this.GetCommentsOperationCompleted, userState);
        }
        
        private void OnGetCommentsCompleted(object arg) {
            if ((this.GetCommentsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCommentsCompleted(this, new GetCommentsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookInfo", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookInfo {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookInfoResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookInfoResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BookName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Author;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BookPic;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BookUri;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Summary;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int TotalPage;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Publisher;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PubDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string binding;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookCover", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookCover {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookCoverResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookCoverResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PicUri;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookRates", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookRates {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookRatesResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookRatesResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RateNum;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookTags", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookTags {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetBookTagsResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookTagsResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TagCount;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TagItem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetBookTagsResponseTagItem[] TagItem;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetBookTagsResponseTagItem {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TagName;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TagNum;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("iPAC", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageIPAC {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("iPACResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageIPACResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Pic_url;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BackUrl;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Total;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("connemtItem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageIPACResponseConnemtItem[] connemtItem;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageIPACResponseConnemtItem {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentTitle;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentAuthor;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentRating;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetComments", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetComments {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    [System.Xml.Serialization.XmlRootAttribute("GetCommentsResponse", Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetCommentsResponse {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ISBN;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("connemtItem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MessageGetCommentsResponseConnemtItem[] connemtItem;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.example.org/LibMobWS_DouBan/")]
    public partial class MessageGetCommentsResponseConnemtItem {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentTitle;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentText;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentAuthor;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CommentRating;
    }
    
    public partial class GetBookInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBookInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageGetBookInfoResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageGetBookInfoResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void GetBookInfoCompletedEventHandler(object sender, GetBookInfoCompletedEventArgs args);
    
    public partial class GetBookCoverCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBookCoverCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageGetBookCoverResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageGetBookCoverResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void GetBookCoverCompletedEventHandler(object sender, GetBookCoverCompletedEventArgs args);
    
    public partial class GetBookRatesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBookRatesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageGetBookRatesResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageGetBookRatesResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void GetBookRatesCompletedEventHandler(object sender, GetBookRatesCompletedEventArgs args);
    
    public partial class GetBookTagsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBookTagsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageGetBookTagsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageGetBookTagsResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void GetBookTagsCompletedEventHandler(object sender, GetBookTagsCompletedEventArgs args);
    
    public partial class iPACCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal iPACCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageIPACResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageIPACResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void iPACCompletedEventHandler(object sender, iPACCompletedEventArgs args);
    
    public partial class GetCommentsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCommentsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MessageGetCommentsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MessageGetCommentsResponse)(this.results[0]));
            }
        }
    }
    
    public delegate void GetCommentsCompletedEventHandler(object sender, GetCommentsCompletedEventArgs args);
}