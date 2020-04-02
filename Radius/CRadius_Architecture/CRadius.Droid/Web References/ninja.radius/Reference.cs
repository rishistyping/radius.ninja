﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CRadius.Droid.ninja.radius {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IRadius", Namespace="http://tempuri.org/")]
    public partial class Radius : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HandshakeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Radius() {
            this.Url = "http://radius.ninja/services/Radius.svc";
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
        public event HandshakeCompletedEventHandler HandshakeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRadius/Handshake", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Payload Handshake() {
            object[] results = this.Invoke("Handshake", new object[0]);
            return ((Payload)(results[0]));
        }
        
        /// <remarks/>
        public void HandshakeAsync() {
            this.HandshakeAsync(null);
        }
        
        /// <remarks/>
        public void HandshakeAsync(object userState) {
            if ((this.HandshakeOperationCompleted == null)) {
                this.HandshakeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHandshakeOperationCompleted);
            }
            this.InvokeAsync("Handshake", new object[0], this.HandshakeOperationCompleted, userState);
        }
        
        private void OnHandshakeOperationCompleted(object arg) {
            if ((this.HandshakeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HandshakeCompleted(this, new HandshakeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CRadius")]
    public partial class Payload {
        
        private bool errorField;
        
        private bool errorFieldSpecified;
        
        private string messageField;
        
        private Rule[] rulesField;
        
        private bool showstopperField;
        
        private bool showstopperFieldSpecified;
        
        /// <remarks/>
        public bool Error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ErrorSpecified {
            get {
                return this.errorFieldSpecified;
            }
            set {
                this.errorFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        public Rule[] Rules {
            get {
                return this.rulesField;
            }
            set {
                this.rulesField = value;
            }
        }
        
        /// <remarks/>
        public bool Showstopper {
            get {
                return this.showstopperField;
            }
            set {
                this.showstopperField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ShowstopperSpecified {
            get {
                return this.showstopperFieldSpecified;
            }
            set {
                this.showstopperFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/CRadius")]
    public partial class Rule {
        
        private int directionField;
        
        private bool directionFieldSpecified;
        
        private bool dismissedField;
        
        private bool dismissedFieldSpecified;
        
        private decimal distanceField;
        
        private bool distanceFieldSpecified;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private string locationNameField;
        
        private int locationStateField;
        
        private bool locationStateFieldSpecified;
        
        private decimal mapLatitudeField;
        
        private bool mapLatitudeFieldSpecified;
        
        private decimal mapLongitudeField;
        
        private bool mapLongitudeFieldSpecified;
        
        private string messageField;
        
        private decimal radiusKField;
        
        private bool radiusKFieldSpecified;
        
        private decimal warnKField;
        
        private bool warnKFieldSpecified;
        
        /// <remarks/>
        public int Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DirectionSpecified {
            get {
                return this.directionFieldSpecified;
            }
            set {
                this.directionFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool Dismissed {
            get {
                return this.dismissedField;
            }
            set {
                this.dismissedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DismissedSpecified {
            get {
                return this.dismissedFieldSpecified;
            }
            set {
                this.dismissedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Distance {
            get {
                return this.distanceField;
            }
            set {
                this.distanceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DistanceSpecified {
            get {
                return this.distanceFieldSpecified;
            }
            set {
                this.distanceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string LocationName {
            get {
                return this.locationNameField;
            }
            set {
                this.locationNameField = value;
            }
        }
        
        /// <remarks/>
        public int LocationState {
            get {
                return this.locationStateField;
            }
            set {
                this.locationStateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LocationStateSpecified {
            get {
                return this.locationStateFieldSpecified;
            }
            set {
                this.locationStateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal MapLatitude {
            get {
                return this.mapLatitudeField;
            }
            set {
                this.mapLatitudeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MapLatitudeSpecified {
            get {
                return this.mapLatitudeFieldSpecified;
            }
            set {
                this.mapLatitudeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal MapLongitude {
            get {
                return this.mapLongitudeField;
            }
            set {
                this.mapLongitudeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MapLongitudeSpecified {
            get {
                return this.mapLongitudeFieldSpecified;
            }
            set {
                this.mapLongitudeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public decimal RadiusK {
            get {
                return this.radiusKField;
            }
            set {
                this.radiusKField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RadiusKSpecified {
            get {
                return this.radiusKFieldSpecified;
            }
            set {
                this.radiusKFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal WarnK {
            get {
                return this.warnKField;
            }
            set {
                this.warnKField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WarnKSpecified {
            get {
                return this.warnKFieldSpecified;
            }
            set {
                this.warnKFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void HandshakeCompletedEventHandler(object sender, HandshakeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HandshakeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HandshakeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Payload Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Payload)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591