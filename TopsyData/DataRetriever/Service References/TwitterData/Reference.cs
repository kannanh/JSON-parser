﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataRetriever.TwitterData {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TweetData", Namespace="http://schemas.datacontract.org/2004/07/TopsyData")]
    [System.SerializableAttribute()]
    public partial class TweetData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DataRetriever.TwitterData.ResponseList responseField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DataRetriever.TwitterData.ResponseList response {
            get {
                return this.responseField;
            }
            set {
                if ((object.ReferenceEquals(this.responseField, value) != true)) {
                    this.responseField = value;
                    this.RaisePropertyChanged("response");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseList", Namespace="http://schemas.datacontract.org/2004/07/TopsyData")]
    [System.SerializableAttribute()]
    public partial class ResponseList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DataRetriever.TwitterData.Tweet[] listField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int totalField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DataRetriever.TwitterData.Tweet[] list {
            get {
                return this.listField;
            }
            set {
                if ((object.ReferenceEquals(this.listField, value) != true)) {
                    this.listField = value;
                    this.RaisePropertyChanged("list");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int total {
            get {
                return this.totalField;
            }
            set {
                if ((this.totalField.Equals(value) != true)) {
                    this.totalField = value;
                    this.RaisePropertyChanged("total");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tweet", Namespace="http://schemas.datacontract.org/2004/07/TopsyData")]
    [System.SerializableAttribute()]
    public partial class Tweet : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string trackback_author_nickField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int trackback_dateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string content {
            get {
                return this.contentField;
            }
            set {
                if ((object.ReferenceEquals(this.contentField, value) != true)) {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string trackback_author_nick {
            get {
                return this.trackback_author_nickField;
            }
            set {
                if ((object.ReferenceEquals(this.trackback_author_nickField, value) != true)) {
                    this.trackback_author_nickField = value;
                    this.RaisePropertyChanged("trackback_author_nick");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int trackback_date {
            get {
                return this.trackback_dateField;
            }
            set {
                if ((this.trackback_dateField.Equals(value) != true)) {
                    this.trackback_dateField = value;
                    this.RaisePropertyChanged("trackback_date");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TwitterData.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getTwitterData", ReplyAction="http://tempuri.org/IService1/getTwitterDataResponse")]
        DataRetriever.TwitterData.TweetData getTwitterData(string username, int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getTwitterData", ReplyAction="http://tempuri.org/IService1/getTwitterDataResponse")]
        System.Threading.Tasks.Task<DataRetriever.TwitterData.TweetData> getTwitterDataAsync(string username, int page);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : DataRetriever.TwitterData.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<DataRetriever.TwitterData.IService1>, DataRetriever.TwitterData.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DataRetriever.TwitterData.TweetData getTwitterData(string username, int page) {
            return base.Channel.getTwitterData(username, page);
        }
        
        public System.Threading.Tasks.Task<DataRetriever.TwitterData.TweetData> getTwitterDataAsync(string username, int page) {
            return base.Channel.getTwitterDataAsync(username, page);
        }
    }
}