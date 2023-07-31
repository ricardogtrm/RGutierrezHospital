using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGutierrezHospitalEntities context = new DL.RGutierrezHospitalEntities())
                {
                    var query = context.TipoSangreGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();
                            tipoSangre.IdTipoSangre = item.IdTipoSangre;
                            tipoSangre.Nombre = item.Nombre;

                            result.Objects.Add(tipoSangre);
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
    }
}
