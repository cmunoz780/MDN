﻿using System;

//------------------------------------------------------------------------------
// <generado automáticamente>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </generado automáticamente>
//------------------------------------------------------------------------------

namespace CPEngine.Models.Entity
{
    /// <summary>
    /// Clase Dominio CampanaEntity
    /// </summary>
    /// <author>@Charly</author>
    /// <created>05-09-2017 23:30:51</created>
    /// <remarks>
    /// Esta clase fué generada automáticamente por una herramienta.
    /// Para modificarla, debes modificar su correspondiente tabla en la Base de Datos y luego generar nuevamente esta clase usando la herramienta
    /// </remarks>
    public class CampanaEntity
    {

        /// <summary>
        /// CodCamp
        /// </summary>
        public int CodCamp { get; set; }

        /// <summary>
        /// IdentidadCamp
        /// </summary>
        public string IdentidadCamp { get; set; }

        /// <summary>
        /// Activa
        /// </summary>
        public bool Activa { get; set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CampanaEntity"/>.
        /// </summary>
        public CampanaEntity()
        {
            CodCamp = 0;
            IdentidadCamp = string.Empty;
            Activa = false;

        }
    }
}
