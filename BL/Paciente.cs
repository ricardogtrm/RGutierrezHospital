using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {
                    int query = context.PacienteAdd(paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno,
                        paciente.FechaNacimiento, paciente.FechaIngreso, paciente.TipoSangre.IdTipoSangre,
                        paciente.Sexo, paciente.Sintomas);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Paciente registrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {
                    int query = context.PacienteDelete(idPaciente);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Paciente registrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {
                    var query = context.PacienteGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = item.IdPaciente;
                            paciente.Nombre = item.Nombre;
                            paciente.ApellidoPaterno = item.ApellidoPaterno;
                            paciente.ApellidoMaterno = item.ApellidoMaterno;
                            paciente.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            paciente.FechaIngreso = item.FechaIngreso.Value.ToString("dd/MM/yyyy");
                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = item.IdTipoSangre.Value;
                            paciente.TipoSangre.Nombre = item.TipoSangre;
                            paciente.Sexo = item.Sexo;
                            paciente.Sintomas = item.Sintomas;

                            result.Objects.Add(paciente);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {

                    var query = context.PacienteGetById(idPaciente).AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre = query.Nombre;
                        paciente.ApellidoPaterno = query.ApellidoPaterno;
                        paciente.ApellidoMaterno = query.ApellidoMaterno;
                        paciente.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        paciente.FechaIngreso = query.FechaIngreso.Value.ToString("dd/MM/yyyy");
                        paciente.TipoSangre = new ML.TipoSangre();
                        paciente.TipoSangre.IdTipoSangre = query.IdTipoSangre.Value;
                        paciente.TipoSangre.Nombre = query.TipoSangre;
                        paciente.Sexo = query.Sexo;
                        paciente.Sintomas = query.Sintomas;

                        result.Object = paciente;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {
                    int query = context.PacienteUpdate(paciente.IdPaciente, paciente.Nombre, paciente.ApellidoPaterno, paciente.ApellidoMaterno,
                        paciente.FechaNacimiento, paciente.FechaIngreso, paciente.TipoSangre.IdTipoSangre,
                        paciente.Sexo, paciente.Sintomas);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Paciente registrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
