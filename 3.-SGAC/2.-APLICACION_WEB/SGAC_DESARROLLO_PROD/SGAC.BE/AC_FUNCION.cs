//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace SGAC.BE
{
    [DataContract(IsReference = true)]
    public partial class AC_FUNCION: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int func_IFuncionId
        {
            get { return _func_IFuncionId; }
            set
            {
                if (_func_IFuncionId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'func_IFuncionId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _func_IFuncionId = value;
                    OnPropertyChanged("func_IFuncionId");
                }
            }
        }
        private int _func_IFuncionId;
    
        [DataMember]
        public string func_vAccion
        {
            get { return _func_vAccion; }
            set
            {
                if (_func_vAccion != value)
                {
                    _func_vAccion = value;
                    OnPropertyChanged("func_vAccion");
                }
            }
        }
        private string _func_vAccion;
    
        [DataMember]
        public string func_vEntidad
        {
            get { return _func_vEntidad; }
            set
            {
                if (_func_vEntidad != value)
                {
                    _func_vEntidad = value;
                    OnPropertyChanged("func_vEntidad");
                }
            }
        }
        private string _func_vEntidad;
    
        [DataMember]
        public string func_vNombreEnsamblado
        {
            get { return _func_vNombreEnsamblado; }
            set
            {
                if (_func_vNombreEnsamblado != value)
                {
                    _func_vNombreEnsamblado = value;
                    OnPropertyChanged("func_vNombreEnsamblado");
                }
            }
        }
        private string _func_vNombreEnsamblado;
    
        [DataMember]
        public string func_vNombreClase
        {
            get { return _func_vNombreClase; }
            set
            {
                if (_func_vNombreClase != value)
                {
                    _func_vNombreClase = value;
                    OnPropertyChanged("func_vNombreClase");
                }
            }
        }
        private string _func_vNombreClase;
    
        [DataMember]
        public string func_vNombreFuncion
        {
            get { return _func_vNombreFuncion; }
            set
            {
                if (_func_vNombreFuncion != value)
                {
                    _func_vNombreFuncion = value;
                    OnPropertyChanged("func_vNombreFuncion");
                }
            }
        }
        private string _func_vNombreFuncion;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
    
    
    
    
    		private Int16 _sOficinaConsularId;
    	[DataMember]
        public Int16 OficinaConsularId
        {
            get
            {
    			return _sOficinaConsularId;
    		}
    		set
    		{
    			_sOficinaConsularId = value;
    		}
    	}
    	private Int16 _sDiferenciaHoraria;
    	[DataMember]
        public Int16 DiferenciaHoraria
        {
            get
            {
    			return _sDiferenciaHoraria;
    		}
    		set
    		{
    			_sDiferenciaHoraria = value;
    		}
    	}
    	private Int16 _sHorarioVerano;
    	[DataMember]
        public Int16 HorarioVerano
        {
            get
            {
    			return _sHorarioVerano;
    		}
    		set
    		{
    			_sHorarioVerano = value;
    		}
    	}
    
    
    
    
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
        }

        #endregion
    }
}