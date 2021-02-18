﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalStoreClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDetails", Namespace="http://schemas.datacontract.org/2004/07/MedicalStore")]
    [System.SerializableAttribute()]
    public partial class UserDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IRegistrationService")]
    public interface IRegistrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/InsertUserDetails", ReplyAction="http://tempuri.org/IRegistrationService/InsertUserDetailsResponse")]
        string InsertUserDetails(MedicalStoreClient.ServiceReference1.UserDetails userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/InsertUserDetails", ReplyAction="http://tempuri.org/IRegistrationService/InsertUserDetailsResponse")]
        System.Threading.Tasks.Task<string> InsertUserDetailsAsync(MedicalStoreClient.ServiceReference1.UserDetails userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/SelectUserDetails", ReplyAction="http://tempuri.org/IRegistrationService/SelectUserDetailsResponse")]
        System.Data.DataSet SelectUserDetails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/SelectUserDetails", ReplyAction="http://tempuri.org/IRegistrationService/SelectUserDetailsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectUserDetailsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrationServiceChannel : MedicalStoreClient.ServiceReference1.IRegistrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationServiceClient : System.ServiceModel.ClientBase<MedicalStoreClient.ServiceReference1.IRegistrationService>, MedicalStoreClient.ServiceReference1.IRegistrationService {
        
        public RegistrationServiceClient() {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string InsertUserDetails(MedicalStoreClient.ServiceReference1.UserDetails userInfo) {
            return base.Channel.InsertUserDetails(userInfo);
        }
        
        public System.Threading.Tasks.Task<string> InsertUserDetailsAsync(MedicalStoreClient.ServiceReference1.UserDetails userInfo) {
            return base.Channel.InsertUserDetailsAsync(userInfo);
        }
        
        public System.Data.DataSet SelectUserDetails() {
            return base.Channel.SelectUserDetails();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectUserDetailsAsync() {
            return base.Channel.SelectUserDetailsAsync();
        }
    }
}
