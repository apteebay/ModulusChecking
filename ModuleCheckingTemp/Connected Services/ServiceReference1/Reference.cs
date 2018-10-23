﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModuleCheckingTemp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SortCodeModulus", Namespace="http://schemas.datacontract.org/2004/07/ModulusCheckingBL")]
    [System.SerializableAttribute()]
    public partial class SortCodeModulus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ModuleCheckingTemp.ServiceReference1.SortCodeModulus AdditionalCheckField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short ExtField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ImplementedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short ModulusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SortCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ValidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short[] WeightsField;
        
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
        public string AccountNumber {
            get {
                return this.AccountNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountNumberField, value) != true)) {
                    this.AccountNumberField = value;
                    this.RaisePropertyChanged("AccountNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ModuleCheckingTemp.ServiceReference1.SortCodeModulus AdditionalCheck {
            get {
                return this.AdditionalCheckField;
            }
            set {
                if ((object.ReferenceEquals(this.AdditionalCheckField, value) != true)) {
                    this.AdditionalCheckField = value;
                    this.RaisePropertyChanged("AdditionalCheck");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Ext {
            get {
                return this.ExtField;
            }
            set {
                if ((this.ExtField.Equals(value) != true)) {
                    this.ExtField = value;
                    this.RaisePropertyChanged("Ext");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Implemented {
            get {
                return this.ImplementedField;
            }
            set {
                if ((this.ImplementedField.Equals(value) != true)) {
                    this.ImplementedField = value;
                    this.RaisePropertyChanged("Implemented");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Modulus {
            get {
                return this.ModulusField;
            }
            set {
                if ((this.ModulusField.Equals(value) != true)) {
                    this.ModulusField = value;
                    this.RaisePropertyChanged("Modulus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SortCode {
            get {
                return this.SortCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.SortCodeField, value) != true)) {
                    this.SortCodeField = value;
                    this.RaisePropertyChanged("SortCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Valid {
            get {
                return this.ValidField;
            }
            set {
                if ((this.ValidField.Equals(value) != true)) {
                    this.ValidField = value;
                    this.RaisePropertyChanged("Valid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short[] Weights {
            get {
                return this.WeightsField;
            }
            set {
                if ((object.ReferenceEquals(this.WeightsField, value) != true)) {
                    this.WeightsField = value;
                    this.RaisePropertyChanged("Weights");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IModulusCheckingService")]
    public interface IModulusCheckingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModulusCheckingService/GetCheckModulus", ReplyAction="http://tempuri.org/IModulusCheckingService/GetCheckModulusResponse")]
        ModuleCheckingTemp.ServiceReference1.SortCodeModulus GetCheckModulus(string sortCode, string accountNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModulusCheckingService/GetCheckModulus", ReplyAction="http://tempuri.org/IModulusCheckingService/GetCheckModulusResponse")]
        System.Threading.Tasks.Task<ModuleCheckingTemp.ServiceReference1.SortCodeModulus> GetCheckModulusAsync(string sortCode, string accountNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModulusCheckingServiceChannel : ModuleCheckingTemp.ServiceReference1.IModulusCheckingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ModulusCheckingServiceClient : System.ServiceModel.ClientBase<ModuleCheckingTemp.ServiceReference1.IModulusCheckingService>, ModuleCheckingTemp.ServiceReference1.IModulusCheckingService {
        
        public ModulusCheckingServiceClient() {
        }
        
        public ModulusCheckingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ModulusCheckingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ModulusCheckingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ModulusCheckingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ModuleCheckingTemp.ServiceReference1.SortCodeModulus GetCheckModulus(string sortCode, string accountNumber) {
            return base.Channel.GetCheckModulus(sortCode, accountNumber);
        }
        
        public System.Threading.Tasks.Task<ModuleCheckingTemp.ServiceReference1.SortCodeModulus> GetCheckModulusAsync(string sortCode, string accountNumber) {
            return base.Channel.GetCheckModulusAsync(sortCode, accountNumber);
        }
    }
}