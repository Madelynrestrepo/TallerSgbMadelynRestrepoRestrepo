using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSgbMadelynRestrepoRestrepo
{
    public interface Biblioteca
    {
        void PrestarLibro(string Titulo, string NombreUsuario);

        void DevolverLibro(string Titulo);

        void MostrarCatalogo();
    }
}
