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
    public partial class RE_REGISTROMILITAR: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public long remi_iRegistroMilitarId
        {
            get { return _remi_iRegistroMilitarId; }
            set
            {
                if (_remi_iRegistroMilitarId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'remi_iRegistroMilitarId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _remi_iRegistroMilitarId = value;
                    OnPropertyChanged("remi_iRegistroMilitarId");
                }
            }
        }
        private long _remi_iRegistroMilitarId;
    
        [DataMember]
        public long remi_iActuacionDetalleId
        {
            get { return _remi_iActuacionDetalleId; }
            set
            {
                if (_remi_iActuacionDetalleId != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_iActuacionDetalleId", _remi_iActuacionDetalleId);
                    if (!IsDeserializing)
                    {
                        if (RE_ACTUACIONDETALLE != null && RE_ACTUACIONDETALLE.acde_iActuacionDetalleId != value)
                        {
                            RE_ACTUACIONDETALLE = null;
                        }
                    }
                    _remi_iActuacionDetalleId = value;
                    OnPropertyChanged("remi_iActuacionDetalleId");
                }
            }
        }
        private long _remi_iActuacionDetalleId;
    
        [DataMember]
        public short remi_sCalificacionMilitarId
        {
            get { return _remi_sCalificacionMilitarId; }
            set
            {
                if (_remi_sCalificacionMilitarId != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_sCalificacionMilitarId", _remi_sCalificacionMilitarId);
                    if (!IsDeserializing)
                    {
                        if (SI_PARAMETRO1 != null && SI_PARAMETRO1.para_sParametroId != value)
                        {
                            SI_PARAMETRO1 = null;
                        }
                    }
                    _remi_sCalificacionMilitarId = value;
                    OnPropertyChanged("remi_sCalificacionMilitarId");
                }
            }
        }
        private short _remi_sCalificacionMilitarId;
    
        [DataMember]
        public short remi_sInstitucionMilitarId
        {
            get { return _remi_sInstitucionMilitarId; }
            set
            {
                if (_remi_sInstitucionMilitarId != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_sInstitucionMilitarId", _remi_sInstitucionMilitarId);
                    if (!IsDeserializing)
                    {
                        if (SI_PARAMETRO != null && SI_PARAMETRO.para_sParametroId != value)
                        {
                            SI_PARAMETRO = null;
                        }
                    }
                    _remi_sInstitucionMilitarId = value;
                    OnPropertyChanged("remi_sInstitucionMilitarId");
                }
            }
        }
        private short _remi_sInstitucionMilitarId;
    
        [DataMember]
        public Nullable<int> remi_IFuncionarioId
        {
            get { return _remi_IFuncionarioId; }
            set
            {
                if (_remi_IFuncionarioId != value)
                {
                    _remi_IFuncionarioId = value;
                    OnPropertyChanged("remi_IFuncionarioId");
                }
            }
        }
        private Nullable<int> _remi_IFuncionarioId;
    
        [DataMember]
        public short remi_sServicioReservaId
        {
            get { return _remi_sServicioReservaId; }
            set
            {
                if (_remi_sServicioReservaId != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_sServicioReservaId", _remi_sServicioReservaId);
                    if (!IsDeserializing)
                    {
                        if (SI_PARAMETRO2 != null && SI_PARAMETRO2.para_sParametroId != value)
                        {
                            SI_PARAMETRO2 = null;
                        }
                    }
                    _remi_sServicioReservaId = value;
                    OnPropertyChanged("remi_sServicioReservaId");
                }
            }
        }
        private short _remi_sServicioReservaId;
    
        [DataMember]
        public string remi_vClase
        {
            get { return _remi_vClase; }
            set
            {
                if (_remi_vClase != value)
                {
                    _remi_vClase = value;
                    OnPropertyChanged("remi_vClase");
                }
            }
        }
        private string _remi_vClase;
    
        [DataMember]
        public string remi_vLibro
        {
            get { return _remi_vLibro; }
            set
            {
                if (_remi_vLibro != value)
                {
                    _remi_vLibro = value;
                    OnPropertyChanged("remi_vLibro");
                }
            }
        }
        private string _remi_vLibro;
    
        [DataMember]
        public Nullable<short> remi_sFolio
        {
            get { return _remi_sFolio; }
            set
            {
                if (_remi_sFolio != value)
                {
                    _remi_sFolio = value;
                    OnPropertyChanged("remi_sFolio");
                }
            }
        }
        private Nullable<short> _remi_sFolio;
    
        [DataMember]
        public short remi_sNumeroHijos
        {
            get { return _remi_sNumeroHijos; }
            set
            {
                if (_remi_sNumeroHijos != value)
                {
                    _remi_sNumeroHijos = value;
                    OnPropertyChanged("remi_sNumeroHijos");
                }
            }
        }
        private short _remi_sNumeroHijos;
    
        [DataMember]
        public Nullable<int> remi_IUsuarioAprobacionId
        {
            get { return _remi_IUsuarioAprobacionId; }
            set
            {
                if (_remi_IUsuarioAprobacionId != value)
                {
                    _remi_IUsuarioAprobacionId = value;
                    OnPropertyChanged("remi_IUsuarioAprobacionId");
                }
            }
        }
        private Nullable<int> _remi_IUsuarioAprobacionId;
    
        [DataMember]
        public string remi_vIPAprobacion
        {
            get { return _remi_vIPAprobacion; }
            set
            {
                if (_remi_vIPAprobacion != value)
                {
                    _remi_vIPAprobacion = value;
                    OnPropertyChanged("remi_vIPAprobacion");
                }
            }
        }
        private string _remi_vIPAprobacion;
    
        [DataMember]
        public Nullable<System.DateTime> remi_dFechaAprobacion
        {
            get { return _remi_dFechaAprobacion; }
            set
            {
                if (_remi_dFechaAprobacion != value)
                {
                    _remi_dFechaAprobacion = value;
                    OnPropertyChanged("remi_dFechaAprobacion");
                }
            }
        }
        private Nullable<System.DateTime> _remi_dFechaAprobacion;
    
        [DataMember]
        public Nullable<bool> remi_bDigitalizadoFlag
        {
            get { return _remi_bDigitalizadoFlag; }
            set
            {
                if (_remi_bDigitalizadoFlag != value)
                {
                    _remi_bDigitalizadoFlag = value;
                    OnPropertyChanged("remi_bDigitalizadoFlag");
                }
            }
        }
        private Nullable<bool> _remi_bDigitalizadoFlag;
    
        [DataMember]
        public string remi_vObservaciones
        {
            get { return _remi_vObservaciones; }
            set
            {
                if (_remi_vObservaciones != value)
                {
                    _remi_vObservaciones = value;
                    OnPropertyChanged("remi_vObservaciones");
                }
            }
        }
        private string _remi_vObservaciones;
    
        [DataMember]
        public string remi_cEstado
        {
            get { return _remi_cEstado; }
            set
            {
                if (_remi_cEstado != value)
                {
                    _remi_cEstado = value;
                    OnPropertyChanged("remi_cEstado");
                }
            }
        }
        private string _remi_cEstado;
    
        [DataMember]
        public short remi_sUsuarioCreacion
        {
            get { return _remi_sUsuarioCreacion; }
            set
            {
                if (_remi_sUsuarioCreacion != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_sUsuarioCreacion", _remi_sUsuarioCreacion);
                    if (!IsDeserializing)
                    {
                        if (SE_USUARIO != null && SE_USUARIO.usua_sUsuarioId != value)
                        {
                            SE_USUARIO = null;
                        }
                    }
                    _remi_sUsuarioCreacion = value;
                    OnPropertyChanged("remi_sUsuarioCreacion");
                }
            }
        }
        private short _remi_sUsuarioCreacion;
    
        [DataMember]
        public string remi_vIPCreacion
        {
            get { return _remi_vIPCreacion; }
            set
            {
                if (_remi_vIPCreacion != value)
                {
                    _remi_vIPCreacion = value;
                    OnPropertyChanged("remi_vIPCreacion");
                }
            }
        }
        private string _remi_vIPCreacion;
    
        [DataMember]
        public System.DateTime remi_dFechaCreacion
        {
            get { return _remi_dFechaCreacion; }
            set
            {
                if (_remi_dFechaCreacion != value)
                {
                    _remi_dFechaCreacion = value;
                    OnPropertyChanged("remi_dFechaCreacion");
                }
            }
        }
        private System.DateTime _remi_dFechaCreacion;
    
        [DataMember]
        public Nullable<short> remi_sUsuarioModificacion
        {
            get { return _remi_sUsuarioModificacion; }
            set
            {
                if (_remi_sUsuarioModificacion != value)
                {
                    ChangeTracker.RecordOriginalValue("remi_sUsuarioModificacion", _remi_sUsuarioModificacion);
                    if (!IsDeserializing)
                    {
                        if (SE_USUARIO1 != null && SE_USUARIO1.usua_sUsuarioId != value)
                        {
                            SE_USUARIO1 = null;
                        }
                    }
                    _remi_sUsuarioModificacion = value;
                    OnPropertyChanged("remi_sUsuarioModificacion");
                }
            }
        }
        private Nullable<short> _remi_sUsuarioModificacion;
    
        [DataMember]
        public string remi_vIPModificacion
        {
            get { return _remi_vIPModificacion; }
            set
            {
                if (_remi_vIPModificacion != value)
                {
                    _remi_vIPModificacion = value;
                    OnPropertyChanged("remi_vIPModificacion");
                }
            }
        }
        private string _remi_vIPModificacion;
    
        [DataMember]
        public Nullable<System.DateTime> remi_dFechaModificacion
        {
            get { return _remi_dFechaModificacion; }
            set
            {
                if (_remi_dFechaModificacion != value)
                {
                    _remi_dFechaModificacion = value;
                    OnPropertyChanged("remi_dFechaModificacion");
                }
            }
        }
        private Nullable<System.DateTime> _remi_dFechaModificacion;
    
        [DataMember]
        public Nullable<short> remi_sTipoSuscripcion
        {
            get { return _remi_sTipoSuscripcion; }
            set
            {
                if (_remi_sTipoSuscripcion != value)
                {
                    _remi_sTipoSuscripcion = value;
                    OnPropertyChanged("remi_sTipoSuscripcion");
                }
            }
        }
        private Nullable<short> _remi_sTipoSuscripcion;

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
    
        [DataMember]
        public SI_PARAMETRO SI_PARAMETRO1
        {
            get { return _sI_PARAMETRO1; }
            set
            {
                if (!ReferenceEquals(_sI_PARAMETRO1, value))
                {
                    var previousValue = _sI_PARAMETRO1;
                    _sI_PARAMETRO1 = value;
                    FixupSI_PARAMETRO1(previousValue);
                    OnNavigationPropertyChanged("SI_PARAMETRO1");
                }
            }
        }
        private SI_PARAMETRO _sI_PARAMETRO1;
    
        [DataMember]
        public SI_PARAMETRO SI_PARAMETRO2
        {
            get { return _sI_PARAMETRO2; }
            set
            {
                if (!ReferenceEquals(_sI_PARAMETRO2, value))
                {
                    var previousValue = _sI_PARAMETRO2;
                    _sI_PARAMETRO2 = value;
                    FixupSI_PARAMETRO2(previousValue);
                    OnNavigationPropertyChanged("SI_PARAMETRO2");
                }
            }
        }
        private SI_PARAMETRO _sI_PARAMETRO2;

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
            SI_PARAMETRO1 = null;
            SI_PARAMETRO2 = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupRE_ACTUACIONDETALLE(RE_ACTUACIONDETALLE previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR.Remove(this);
            }
    
            if (RE_ACTUACIONDETALLE != null)
            {
                if (!RE_ACTUACIONDETALLE.RE_REGISTROMILITAR.Contains(this))
                {
                    RE_ACTUACIONDETALLE.RE_REGISTROMILITAR.Add(this);
                }
    
                remi_iActuacionDetalleId = RE_ACTUACIONDETALLE.acde_iActuacionDetalleId;
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
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR.Remove(this);
            }
    
            if (SE_USUARIO != null)
            {
                if (!SE_USUARIO.RE_REGISTROMILITAR.Contains(this))
                {
                    SE_USUARIO.RE_REGISTROMILITAR.Add(this);
                }
    
                remi_sUsuarioCreacion = SE_USUARIO.usua_sUsuarioId;
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
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR1.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR1.Remove(this);
            }
    
            if (SE_USUARIO1 != null)
            {
                if (!SE_USUARIO1.RE_REGISTROMILITAR1.Contains(this))
                {
                    SE_USUARIO1.RE_REGISTROMILITAR1.Add(this);
                }
    
                remi_sUsuarioModificacion = SE_USUARIO1.usua_sUsuarioId;
            }
            else if (!skipKeys)
            {
                remi_sUsuarioModificacion = null;
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
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR.Remove(this);
            }
    
            if (SI_PARAMETRO != null)
            {
                if (!SI_PARAMETRO.RE_REGISTROMILITAR.Contains(this))
                {
                    SI_PARAMETRO.RE_REGISTROMILITAR.Add(this);
                }
    
                remi_sInstitucionMilitarId = SI_PARAMETRO.para_sParametroId;
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
    
        private void FixupSI_PARAMETRO1(SI_PARAMETRO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR1.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR1.Remove(this);
            }
    
            if (SI_PARAMETRO1 != null)
            {
                if (!SI_PARAMETRO1.RE_REGISTROMILITAR1.Contains(this))
                {
                    SI_PARAMETRO1.RE_REGISTROMILITAR1.Add(this);
                }
    
                remi_sCalificacionMilitarId = SI_PARAMETRO1.para_sParametroId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SI_PARAMETRO1")
                    && (ChangeTracker.OriginalValues["SI_PARAMETRO1"] == SI_PARAMETRO1))
                {
                    ChangeTracker.OriginalValues.Remove("SI_PARAMETRO1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SI_PARAMETRO1", previousValue);
                }
                if (SI_PARAMETRO1 != null && !SI_PARAMETRO1.ChangeTracker.ChangeTrackingEnabled)
                {
                    SI_PARAMETRO1.StartTracking();
                }
            }
        }
    
        private void FixupSI_PARAMETRO2(SI_PARAMETRO previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RE_REGISTROMILITAR2.Contains(this))
            {
                previousValue.RE_REGISTROMILITAR2.Remove(this);
            }
    
            if (SI_PARAMETRO2 != null)
            {
                if (!SI_PARAMETRO2.RE_REGISTROMILITAR2.Contains(this))
                {
                    SI_PARAMETRO2.RE_REGISTROMILITAR2.Add(this);
                }
    
                remi_sServicioReservaId = SI_PARAMETRO2.para_sParametroId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SI_PARAMETRO2")
                    && (ChangeTracker.OriginalValues["SI_PARAMETRO2"] == SI_PARAMETRO2))
                {
                    ChangeTracker.OriginalValues.Remove("SI_PARAMETRO2");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SI_PARAMETRO2", previousValue);
                }
                if (SI_PARAMETRO2 != null && !SI_PARAMETRO2.ChangeTracker.ChangeTrackingEnabled)
                {
                    SI_PARAMETRO2.StartTracking();
                }
            }
        }

        #endregion
    }
}