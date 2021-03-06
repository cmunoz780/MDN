﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Business.Entity;
using System.Data;
using CDK.Data;
using CDK.Integration;

namespace CRM.Business.Data
{
    public class AfiliadoDataAccess
    {
        public static Entity.Afiliados.AfiliadosEntity ObtenerDatosAfi(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("mae.spMotor_BuscarAfiliadoScan", pram, ConstAfiliado);
        }

        //Lista combo
        public static List<Entity.Afiliados.AfiliadoEmpresaEntity> ListaRutEmpresa(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScan_ListaEmpresa", pram, ConstAfiliadoEmpresa);
        }
        public static Entity.Afiliados.EmpresaAfiliadoEntity ObtenerDatosEmpresa(int RutEmpresa, int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutEmpresa", RutEmpresa),
                new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("mae.spMotor_BuscarAfiliadoScan_ObtenerEmpresa", pram, EmpresaAfiliado);
        }
        public static Entity.Afiliados.AfiliadoDatosCumpleanios ObtenerCumpleanos(int RutAfiliado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("scafi.spMotor_MostrarCumpleanos", param, DatosContacto);
        }


        public static List<Entity.Afiliados.AfiliadoCampanas> ListaCampaniasAfi(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                  new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScanCampanas", pram, CampaniaAfiConst);
        }
        public static List<Entity.Afiliados.AlertasAfiliados> ListarAlertasAfiliado(int RutAfiliado)
        {
            Parametros pram = new Parametros
            {
                  new Parametro("@RutAfiliado", RutAfiliado)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("alertafi.spMotor_ListarAlertas", pram, Alertas);
        }

        public static List<Entity.Afiliados.AfiliadoCampanas> ObtenerHistorialCampana(int RutAfiliado, int TipoAsignacion)
        {
            Parametros pram = new Parametros
            {
                new Parametro("@RutAfiliado", RutAfiliado),
                new Parametro("@TipoAsignacion", TipoAsignacion)
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("mae.spMotor_BuscarAfiliadoScanCampanasHist", pram, CampaniaAfiConst_Hitorial);
        }

        private static Entity.Afiliados.AfiliadoEmpresaEntity ConstAfiliadoEmpresa(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoEmpresaEntity
            {
                RutEmpresa = row["rutempresa"] != DBNull.Value ? Convert.ToInt32(row["rutempresa"]) : 0,
                RutEmpresaDv = row["RutEmpresaDv"] != DBNull.Value ? row["RutEmpresaDv"].ToString() : string.Empty,
                NombreEmpresa = row["nombreempresa"] != DBNull.Value ? row["nombreempresa"].ToString() : string.Empty,

            };
        }
        private static Entity.Afiliados.AfiliadoDatosCumpleanios DatosContacto(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoDatosCumpleanios
            {
                Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? Convert.ToInt32(row["RutAfiliado"]) : 0,

            };
        }

        private static Entity.Afiliados.AlertasAfiliados Alertas(DataRow row)
        {

            return new Entity.Afiliados.AlertasAfiliados
            {
                AfiliadoRut = row["RutAfiliado"] != DBNull.Value ? Convert.ToInt32(row["RutAfiliado"]) : 0,
                Tipo = row["Tipo"] != DBNull.Value ? row["Tipo"].ToString() : string.Empty,
                Valor = row["valor"] != DBNull.Value ? row["valor"].ToString() : string.Empty,
                TipoValor = row["TipoAlerta"] != DBNull.Value ? row["TipoAlerta"].ToString() : string.Empty,
            };
        }


        private static Entity.Afiliados.EmpresaAfiliadoEntity EmpresaAfiliado(DataRow row)
        {

            return new Entity.Afiliados.EmpresaAfiliadoEntity
            {
                RutEmpresa = row["rutempresa"] != DBNull.Value ? Convert.ToInt32(row["rutempresa"]) : 0,
                RutEmpresaDv = row["RutEmpresaDv"] != DBNull.Value ? row["RutEmpresaDv"].ToString() : string.Empty,
                NombreEmpresa = row["nombreempresa"] != DBNull.Value ? row["nombreempresa"].ToString() : string.Empty,
                PeriodoUltimaRenta = row["PeriodoUltimaRenta"] != DBNull.Value ? row["PeriodoUltimaRenta"].ToString() : string.Empty,
                RentaUltimaInformada = row["RentaUltimaInformada"] != DBNull.Value ? Convert.ToInt32(row["RentaUltimaInformada"]) : 0,
                RolSegmentoAfiliado = row["RolSegmentoAfiliado"] != DBNull.Value ? row["RolSegmentoAfiliado"].ToString() : string.Empty,


            };
        }
        private static Entity.Afiliados.AfiliadosEntity ConstAfiliado(DataRow row)
        {

            return new Entity.Afiliados.AfiliadosEntity
            {
                Periodo = row["Periodo"] != DBNull.Value ? Convert.ToInt32(row["Periodo"]) : 0,
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Nombres = row["Nombres"] != DBNull.Value ? row["Nombres"].ToString() : string.Empty,
                Apellidos = row["Apellidos"] != DBNull.Value ? row["Apellidos"].ToString() : string.Empty,
                Nacionalidad = row["Nacionalidad"] != DBNull.Value ? row["Nacionalidad"].ToString() : string.Empty,
                Sexo = row["Sexo"] != DBNull.Value ? row["Sexo"].ToString() : string.Empty,
                FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? row["FechaNacimiento"].ToString() : string.Empty,
                Edad = row["Edad"] != DBNull.Value ? Convert.ToInt32(row["Edad"]) : 0,
                EstadoCivil = row["EstadoCivil"] != DBNull.Value ? row["EstadoCivil"].ToString() : string.Empty,
                RolSegmentoAfiliado = row["RolSegmentoAfiliado"] != DBNull.Value ? row["RolSegmentoAfiliado"].ToString() : string.Empty,
                InicioValidezRol = row["InicioValidezRol"] != DBNull.Value ? row["InicioValidezRol"].ToString() : string.Empty,
                FinValidezRol = row["FinValidezRol"] != DBNull.Value ? (row["FinValidezRol"]).ToString() : string.Empty,
                RegimenPrevisional = row["RegimenPrevisional"] != DBNull.Value ? row["RegimenPrevisional"].ToString() : string.Empty,
                RegimenSalud = row["RegimenSalud"] != DBNull.Value ? row["RegimenSalud"].ToString() : string.Empty,
                CargoAfiliado = row["CargoAfiliado"] != DBNull.Value ? row["CargoAfiliado"].ToString() : string.Empty,
                TipoContrato = row["TipoContrato"] != DBNull.Value ? row["TipoContrato"].ToString() : string.Empty,
                PeriodoUltimaRenta = row["PeriodoUltimaRenta"] != DBNull.Value ? Convert.ToInt32(row["PeriodoUltimaRenta"]) : 0,
                RentaUltimaInformada = row["RentaUltimaInformada"] != DBNull.Value ? Convert.ToInt32(row["RentaUltimaInformada"]) : 0,
                RegionAfiliado = row["RegionAfiliado"] != DBNull.Value ? row["RegionAfiliado"].ToString() : string.Empty,
                ComunaAfiliado = row["ComunaAfiliado"] != DBNull.Value ? row["ComunaAfiliado"].ToString() : string.Empty,
                Cel = row["Cel"] != DBNull.Value ? row["Cel"].ToString() : string.Empty,
                Fono = row["Fono"] != DBNull.Value ? row["Fono"].ToString() : string.Empty,
                Mail = row["Mail"] != DBNull.Value ? row["Mail"].ToString() : string.Empty,
                Vigente = row["Vigente"] != DBNull.Value ? Convert.ToInt32(row["Vigente"]) : 0,
                Fallecido = row["Fallecido"] != DBNull.Value ? Convert.ToInt32(row["Fallecido"]) : 0,
                FlagNoMolestar = row["FlagNoMolestar"] != DBNull.Value ? Convert.ToInt32(row["FlagNoMolestar"]) : 0,
                MotivoNM = row["MotivoNM"] != DBNull.Value ? row["MotivoNM"].ToString() : string.Empty,
            };
        }
        private static Entity.Afiliados.AfiliadoCampanas CampaniaAfiConst(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoCampanas
            {
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                RutAfiliado = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                RutDvAfiliado = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Campania = row["Campania"] != DBNull.Value ? row["Campania"].ToString() : string.Empty,
                Oferta = row["Oferta"] != DBNull.Value ? Convert.ToInt32(row["Oferta"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? row["Prioridad"].ToString() : string.Empty,
                id_Asginacion = row["id_Asign"] != DBNull.Value ? Convert.ToInt32(row["id_Asign"]) : 0,
                TipoAsignacion = row["TipoAsignacion"] != DBNull.Value ? Convert.ToInt32(row["TipoAsignacion"]) : 0,
                Estado = row["EstadoGestion"] != DBNull.Value ? row["EstadoGestion"].ToString() : string.Empty,
                SubEstado = row["SubEstadoGestion"] != DBNull.Value ? row["SubEstadoGestion"].ToString() : string.Empty,
                FechaCompromete = row["FComprometeGestion"] != DBNull.Value ? Convert.ToDateTime(row["FComprometeGestion"]) : DateTime.MinValue,

            };
        }
        private static Entity.Afiliados.AfiliadoCampanas CampaniaAfiConst_Hitorial(DataRow row)
        {

            return new Entity.Afiliados.AfiliadoCampanas
            {
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                RutAfiliado = row["Afiliado_Rut"] != DBNull.Value ? Convert.ToInt32(row["Afiliado_Rut"]) : 0,
                RutDvAfiliado = row["Afiliado_Dv"] != DBNull.Value ? row["Afiliado_Dv"].ToString() : string.Empty,
                Campania = row["Campania"] != DBNull.Value ? row["Campania"].ToString() : string.Empty,
                Oferta = row["Oferta"] != DBNull.Value ? Convert.ToInt32(row["Oferta"]) : 0,
                Prioridad = row["Prioridad"] != DBNull.Value ? row["Prioridad"].ToString() : string.Empty,
                id_Asginacion = row["id_Asign"] != DBNull.Value ? Convert.ToInt32(row["id_Asign"]) : 0,
                TipoAsignacion = row["TipoAsignacion"] != DBNull.Value ? Convert.ToInt32(row["TipoAsignacion"]) : 0,
                Estado = row["EstadoGestion"] != DBNull.Value ? row["EstadoGestion"].ToString() : string.Empty,
                SubEstado = row["SubEstadoGestion"] != DBNull.Value ? row["SubEstadoGestion"].ToString() : string.Empty,
                FechaCompromete = row["FComprometeGestion"] != DBNull.Value ? Convert.ToDateTime(row["FComprometeGestion"]) : DateTime.MinValue,
                FechaAccion = row["FechaAccion"] != DBNull.Value ? Convert.ToDateTime(row["FechaAccion"]) : DateTime.MinValue,
                Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : string.Empty,
                Nombres = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                EsTerminal = row["EstadoTerminal"] != DBNull.Value ? row["EstadoTerminal"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.NoMolestarAfiliado AfilidoNoMolestar(string RutAfiliado, string motivo, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Motivo",motivo),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Guarda_NoMolestar", param, Afiliado_NoMolestar);
        }


        private static Entity.Afiliados.NoMolestarAfiliado Afiliado_NoMolestar(DataRow row)
        {
            return new Entity.Afiliados.NoMolestarAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Motivo = row["Motivo"] != DBNull.Value ? row["Motivo"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.ObservacionAfiliado AfiliadoComentario(string RutAfiliado, string Observacion, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Observacion",Observacion),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Guarda_AfiliadoComentario", param, Afiliado_Comentario);
        }

        private static Entity.Afiliados.ObservacionAfiliado Afiliado_Comentario(DataRow row)
        {
            return new Entity.Afiliados.ObservacionAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Observacion = row["Comentario"] != DBNull.Value ? row["Comentario"].ToString() : string.Empty,
            };
        }

        public static Entity.Afiliados.NoMolestarAfiliado sacaMarcaNoMolestar(string RutAfiliado, string token)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@TokenEjecutivo",token),
            };
            return DBHelper.InstanceCRM.ObtenerEntidad("dbo.SpMotor_Saca_Marca_NoMolestar", param, sacaMarca_NoMolestar);
        }

        private static Entity.Afiliados.NoMolestarAfiliado sacaMarca_NoMolestar(DataRow row)
        {
            return new Entity.Afiliados.NoMolestarAfiliado
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
            };
        }


        public static List<Entity.Afiliados.AfiliadoProyeccion> ObtieneProyeccionAfiliado(string RutAfiliado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.SpMotor_Lista_Gestion_lineaTiempo", param, ProyecAfiliado);
        }


        public static List<Entity.Afiliados.AfiliadoProyeccion> FiltroProyeccionAfiliado(string RutAfiliado, int Estado)
        {
            Parametros param = new Parametros
            {
                new Parametro("@RutAfiliado",RutAfiliado),
                new Parametro("@Estado",Estado),
            };
            return DBHelper.InstanceCRM.ObtenerColeccion("dbo.SpMotor_Filtro_Gestion_lineaTiempo", param, ProyecAfiliado);
        }

        private static Entity.Afiliados.AfiliadoProyeccion ProyecAfiliado(DataRow row)
        {
            return new Entity.Afiliados.AfiliadoProyeccion
            {
                RutAfiliado = row["RutAfiliado"] != DBNull.Value ? row["RutAfiliado"].ToString() : string.Empty,
                Fecha = row["Fecha"] != DBNull.Value ? Convert.ToDateTime(row["Fecha"]) : DateTime.MinValue,
                Estado = row["Estado"] != DBNull.Value ? row["Estado"].ToString() : string.Empty,
                SubEstado = row["SubEstado"] != DBNull.Value ? row["SubEstado"].ToString() : string.Empty,
                Afiliado = row["Afiliado"] != DBNull.Value ? row["Afiliado"].ToString() : string.Empty,
                Ejecutivo = row["Ejecutivo"] != DBNull.Value ? row["Ejecutivo"].ToString() : string.Empty,
                Sucursal = row["Sucursal"] != DBNull.Value ? row["Sucursal"].ToString() : string.Empty,
                PreAprobadoFinal = row["PreAprobadoFinal"] != DBNull.Value ? Convert.ToInt32(row["PreAprobadoFinal"]) : 0,
                Periodo = row["Periodo"] != DBNull.Value ? row["Periodo"].ToString() : string.Empty,
                EstadoGestion = row["EstadoGestion"] != DBNull.Value ? Convert.ToInt32(row["EstadoGestion"]) : 0,
            };
        }
    }

}
