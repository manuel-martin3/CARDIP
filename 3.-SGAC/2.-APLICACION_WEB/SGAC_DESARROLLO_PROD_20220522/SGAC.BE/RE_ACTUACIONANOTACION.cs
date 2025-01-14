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
    [KnownType(typeof(RE_ACTUACIONDETALLE))]
    [KnownType(typeof(SE_USUARIO))]
    [KnownType(typeof(SI_PARAMETRO))]
    public partial class RE_ACTUACIONANOTACION: IObjectWithChangeTracker, INotifyPropertyChanged
    {

        public String vDescripcionCorta { get; set; }
        #region Primitive Properties
    
        [DataMember]
        public long anot_iActuacionAnotacionId
        {
            get { return _anot_iActuacionAnotacionId; }
            set
            {
                if (_anot_iActuacionAnotacionId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'anot_iActuacionAnotacionId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _anot_iActuacionAnotacionId = value;
                    OnPropertyChanged("anot_iActuacionAnotacionId");
                }
            }
        }
        private long _anot_iActuacionAnotacionId;
    
        [DataMember]
        public long anot_iActuacionDetalleId
        {
            get { return _anot_iActuacionDetalleId; }
            set
            {
                if (_anot_iActuacionDetalleId != value)
                {
                    ChangeTracker.RecordOriginalValue("anot_iActuacionDetalleId", _anot_iActuacionDetalleId);
                    if (!IsDeserializing)
                    {
                        if (RE_ACTUACIONDETALLE != null && RE_ACTUACIONDETALLE.acde_iActuacionDetalleId != value)
                        {
                            RE_ACTUACIONDETALLE = null;
                        }
                    }
                    _anot_iActuacionDetalleId = value;
                    OnPropertyChanged("anot_iActuacionDetalleId");
                }
            }
        }
        private long _anot_iActuacionDetalleId;
    
        [DataMember]
        public short anot_sTipoAnotacionId
        {
            get { return _anot_sTipoAnotacionId; }
            set
            {
                if (_anot_sTipoAnotacionId != value)
                {
                    ChangeTracker.RecordOriginalValue("anot_sTipoAnotacionId", _anot_sTipoAnotacionId);
                    if (!IsDeserializing)
                    {
                        if (SI_PARAMETRO != null && SI_PARAMETRO.para_sParametroId != value)
                        {
                            SI_PARAMETRO = null;
                        }
                    }
                    _anot_sTipoAnotacionId = value;
                    OnPropertyChanged("anot_sTipoAnotacionId");
                }
            }
        }
        private short _anot_sTipoAnotacionId;
    
        [DataMember]
        public Nullable<int> anot_iNumeroActaAnterior
        {
            get { return _anot_iNumeroActaAnterior; }
            set
            {
                if (_anot_iNumeroActaAnterior != value)
                {
                    _anot_iNumeroActaAnterior = value;
                    OnPropertyChanged("anot_iNumeroActaAnterior");
                }
            }
        }
        private Nullable<int> _anot_iNumeroActaAnterior;
    
        [DataMember]
        public Nullable<short> anot_sMotivoCancelacion
        {
            get { return _anot_sMotivoCancelacion; }
            set
            {
                if (_anot_sMotivoCancelacion != value)
                {
                    _anot_sMotivoCancelacion = value;
                    OnPropertyChanged("anot_sMotivoCancelacion");
                }
            }
        }
        private Nullable<short> _anot_sMotivoCancelacion;
    
        [DataMember]
        public System.DateTime anot_dFechaRegistro
        {
            get { return _anot_dFechaRegistro; }
            set
            {
                if (_anot_dFechaRegistro != value)
                {
                    _anot_dFechaRegistro = value;
                    OnPropertyChanged("anot_dFechaRegistro");
                }
            }
        }
        private System.DateTime _anot_dFechaRegistro;
    
        [DataMember]
        public string anot_vComentarios
        {
            get { return _anot_vComentarios; }
            set
            {
                if (_anot_vComentarios != value)
                {
                    _anot_vComentarios = value;
                    OnPropertyChanged("anot_vComentarios");
                }
            }
        }
        private string _anot_vComentarios;
    
        [DataMember]
        public string anot_cEstado
        {
            get { return _anot_cEstado; }
            set
            {
                if (_anot_cEstado != value)
                {
                    _anot_cEstado = value;
                    OnPropertyChanged("anot_cEstado");
                }
            }
        }
        private string _anot_cEstado;
    
        [DataMember]
        public short anot_sUsuarioCreacion
        {
            get { return _anot_sUsuarioCreacion; }
            set
            {
                if (_anot_sUsuarioCreacion != value)
                {
                    ChangeTracker.RecordOriginalValue("anot_sUsuarioCreacion", _anot_sUsuarioCreacion);
                    if (!IsDeserializing)
                    {
                        if (SE_USUARIO != null && SE_USUARIO.usua_sUsuarioId != value)
                        {
                            SE_USUARIO = null;
                        }
                    }
                    _anot_sUsuarioCreacion = value;
                    OnPropertyChanged("anot_sUsuarioCreacion");
                }
            }
        }
        private short _anot_sUsuarioCreacion;
    
        [DataMember]
        public string anot_vIPCreacion
        {
            get { return _anot_vIPCreacion; }
            set
            {
                if (_anot_vIPCreacion != value)
                {
                    _anot_vIPCreacion = value;
                    OnPropertyChanged("anot_vIPCreacion");
                }
            }
        }
        private string _anot_vIPCreacion;
    
        [DataMember]
        public System.DateTime anot_dFechaCreacion
        {
            get { return _anot_dFechaCreacion; }
            set
            {
                if (_anot_dFechaCreacion != value)
                {
                    _anot_dFechaCreacion = value;
                    OnPropertyChanged("anot_dFechaCreacion");
                }
            }
        }
        private System.DateTime _anot_dFechaCreacion;
    
        [DataMember]
        public Nullable<short> anot_sUsuarioModificacion
        {
            get { return _anot_sUsuarioModificacion; }
            set
            {
                if (_anot_sUsuarioModificacion != value)
                {
                    ChangeTracker.RecordOriginalValue("anot_sUsuarioModificacion", _anot_sUsuarioModificacion);
                    if (!IsDeserializing)
                    {
                        if (SE_USUARIO1 != null && SE_USUARIO1.usua_sUsuarioId != value)
                        {
                            SE_USUARIO1 = null;
                        }
                    }
                    _anot_sUsuarioModificacion = value;
                    OnPropertyChanged("anot_sUsuarioModificacion");
                }
            }
        }
        private Nullable<short> _anot_sUsuarioModificacion;
    
        [DataMember]
        public string anot_vIPModificacion
        {
            get { return _anot_vIPModificacion; }
            set
            {
                if (_anot_vIPModificacion != value)
                {
                    _anot_vIPModificacion = value;
                    OnPropertyChanged("anot_vIPModificacion");
                }
            }
        }
        private string _anot_vIPModificacion;
    
        [DataMember]
        public Nullable<System.DateTime> anot_dFechaModificacion
        {
            get { return _anot_dFechaModificacion; }
            set
            {
                if (_anot_dFechaModificacion != value)
                {
                    _anot_dFechaModificacion = value;
                    OnPropertyChanged("anot_dFechaModificacion");
                }
            }
        }
        private Nullable<System.DateTime> _anot_dFechaModificacion;

        //------------------------------------------------
        // Fecha: 13/09/2018
        // Autor: Miguel M�rquez Beltr�n
        // Objetivo: Se adiciona dos atributos a la clase
        //------------------------------------------------


        public Nullable<short> anot_sTipoActaId { get; set; }

        public string anot_vTitular { get; set; }

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public RE_ACTUACIONDETALLE RE_ACTUACIONDETALLE
        {
            get { return _rE_ACTUACIONDETALLE; }
            set
            {
                if (!ReferenceEquals(_rE_ACTUACIONDETALLE, value))
                {
                    var previousValue = _rE_ACTUACIONDETALLE;
                    _rE_ACTUACIONDETALLE = value;
                    FixupRE_ACTUACIONDETALLE(previousValue);
                    OnNavigationPropertyChanged("RE_ACTUACIONDETALLE");
                }
            }
        }
        private RE_ACTUACIONDETALLE _rE_ACTUACIONDETALLE;
    
        [DataMember]
        public SE_USUARIO SE_USUARIO
        {
            get { return _sE_USUARIO; }
            set
            {
                if (!ReferenceEquals(_sE_USUARIO, value))
                {
                    var previousValue = _sE_USUARIO;
                    _sE_USUARIO = value;
                    FixupSE_USUARIO(previousValue);
                    OnNavigationPropertyChanged("SE_USUARIO");
                }
            }
        }
        private SE_USUARIO _sE_USUARIO;
    
        [DataMember]
        public SE_USUARIO SE_USUARIO1
        {
            get { return _sE_USUARIO1; }
            set
            {
                if (!ReferenceEquals(_sE_USUARIO1, value))
                {
                    var previousValue = _sE_USUARIO1;
                    _sE_USUARIO1 = value;
                    FixupSE_USUARIO1(previousValue);
                    OnNavigationPropertyChanged("SE_USUARIO1");
                }
            }
        }
        private SE_USUARIO _sE_USUARIO1;
    
        [DataMember]
        public SI_PARAMETRO SI_PARAMETRO
        {
            get { return _sI_PARAMETRO; }
            set
            {
                if (!ReferenceEquals(_sI_PARAMETRO, value))
                {
                    var previousValue = _sI_PARAMETRO;
                    _sI_PARAMETRO = value;
                    FixupSI_PARAMETRO(previousValue);
                    OnNavigationPropertyChanged("SI_PARAMETRO");
                }
            }
        }
        private SI_PARAMETRO _sI_PARAMETRO;

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
            RE_ACTUACIONDETALLE = null;
            SE_USUARIO = null;
            SE_USUARIO1 = null;
            SI_PARAMETRO = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupRE_ACTUACIONDETALLE(RE_ACTUACIONDETALLE previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_ACTUACIONANOTACION.Contains(this))
            {
                previousValue.RE_ACTUACIONANOTACION.Remove(this);
            }
    
            if (RE_ACTUACIONDETALLE != null)
            {
                if (!RE_ACTUACIONDETALLE.RE_ACTUACIONANOTACION.Contains(this))
                {
                    RE_ACTUACIONDETALLE.RE_ACTUACIONANOTACION.Add(this);
                }
    
                anot_iActuacionDetalleId = RE_ACTUACIONDETALLE.acde_iActuacionDetalleId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("RE_ACTUACIONDETALLE")
                    && (ChangeTracker.OriginalValues["RE_ACTUACIONDETALLE"] == RE_ACTUACIONDETALLE))
                {
                    ChangeTracker.OriginalValues.Remove("RE_ACTUACIONDETALLE");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("RE_ACTUACIONDETALLE", previousValue);
                }
                if (RE_ACTUACIONDETALLE != null && !RE_ACTUACIONDETALLE.ChangeTracker.ChangeTrackingEnabled)
                {
                    RE_ACTUACIONDETALLE.StartTracking();
                }
            }
        }
    
        private void FixupSE_USUARIO(SE_USUARIO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_ACTUACIONANOTACION.Contains(this))
            {
                previousValue.RE_ACTUACIONANOTACION.Remove(this);
            }
    
            if (SE_USUARIO != null)
            {
                if (!SE_USUARIO.RE_ACTUACIONANOTACION.Contains(this))
                {
                    SE_USUARIO.RE_ACTUACIONANOTACION.Add(this);
                }
    
                anot_sUsuarioCreacion = SE_USUARIO.usua_sUsuarioId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SE_USUARIO")
                    && (ChangeTracker.OriginalValues["SE_USUARIO"] == SE_USUARIO))
                {
                    ChangeTracker.OriginalValues.Remove("SE_USUARIO");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SE_USUARIO", previousValue);
                }
                if (SE_USUARIO != null && !SE_USUARIO.ChangeTracker.ChangeTrackingEnabled)
                {
                    SE_USUARIO.StartTracking();
                }
            }
        }
    
        private void FixupSE_USUARIO1(SE_USUARIO previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_ACTUACIONANOTACION1.Contains(this))
            {
                previousValue.RE_ACTUACIONANOTACION1.Remove(this);
            }
    
            if (SE_USUARIO1 != null)
            {
                if (!SE_USUARIO1.RE_ACTUACIONANOTACION1.Contains(this))
                {
                    SE_USUARIO1.RE_ACTUACIONANOTACION1.Add(this);
                }
    
                anot_sUsuarioModificacion = SE_USUARIO1.usua_sUsuarioId;
            }
            else if (!skipKeys)
            {
                anot_sUsuarioModificacion = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SE_USUARIO1")
                    && (ChangeTracker.OriginalValues["SE_USUARIO1"] == SE_USUARIO1))
                {
                    ChangeTracker.OriginalValues.Remove("SE_USUARIO1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SE_USUARIO1", previousValue);
                }
                if (SE_USUARIO1 != null && !SE_USUARIO1.ChangeTracker.ChangeTrackingEnabled)
                {
                    SE_USUARIO1.StartTracking();
                }
            }
        }
    
        private void FixupSI_PARAMETRO(SI_PARAMETRO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_ACTUACIONANOTACION.Contains(this))
            {
                previousValue.RE_ACTUACIONANOTACION.Remove(this);
            }
    
            if (SI_PARAMETRO != null)
            {
                if (!SI_PARAMETRO.RE_ACTUACIONANOTACION.Contains(this))
                {
                    SI_PARAMETRO.RE_ACTUACIONANOTACION.Add(this);
                }
    
                anot_sTipoAnotacionId = SI_PARAMETRO.para_sParametroId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SI_PARAMETRO")
                    && (ChangeTracker.OriginalValues["SI_PARAMETRO"] == SI_PARAMETRO))
                {
                    ChangeTracker.OriginalValues.Remove("SI_PARAMETRO");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SI_PARAMETRO", previousValue);
                }
                if (SI_PARAMETRO != null && !SI_PARAMETRO.ChangeTracker.ChangeTrackingEnabled)
                {
                    SI_PARAMETRO.StartTracking();
                }
            }
        }

        #endregion
    }
}
