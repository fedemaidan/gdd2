using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Model
{
    class UserAdmin : User
    {

        public UserAdmin() { }

        public UserAdmin(Dictionary<String, Object> values)
        {
            this.fillProperties(values);
            this.rol = "Administrador";
        }

    }
}
