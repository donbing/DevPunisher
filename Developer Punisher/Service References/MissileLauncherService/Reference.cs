﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Developer_Punisher.MissileLauncherService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MissileLauncherCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.LeftCommand))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.FireCommand))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.StopCommand))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.DownCommand))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.UpCommand))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Developer_Punisher.MissileLauncherService.RightCommand))]
    public partial class MissileLauncherCommand : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.Runtime.Serialization.DataContractAttribute(Name="LeftCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class LeftCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FireCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class FireCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StopCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class StopCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DownCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class DownCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class UpCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RightCommand", Namespace="http://schemas.datacontract.org/2004/07/Missile_Launcher_Service")]
    [System.SerializableAttribute()]
    public partial class RightCommand : Developer_Punisher.MissileLauncherService.MissileLauncherCommand {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MissileLauncherService.IMissileLauncherService")]
    public interface IMissileLauncherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMissileLauncherService/Execute", ReplyAction="http://tempuri.org/IMissileLauncherService/ExecuteResponse")]
        void Execute(Developer_Punisher.MissileLauncherService.MissileLauncherCommand command);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMissileLauncherServiceChannel : Developer_Punisher.MissileLauncherService.IMissileLauncherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MissileLauncherServiceClient : System.ServiceModel.ClientBase<Developer_Punisher.MissileLauncherService.IMissileLauncherService>, Developer_Punisher.MissileLauncherService.IMissileLauncherService {
        
        public MissileLauncherServiceClient() {
        }
        
        public MissileLauncherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MissileLauncherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MissileLauncherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MissileLauncherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Execute(Developer_Punisher.MissileLauncherService.MissileLauncherCommand command) {
            base.Channel.Execute(command);
        }
    }
}
