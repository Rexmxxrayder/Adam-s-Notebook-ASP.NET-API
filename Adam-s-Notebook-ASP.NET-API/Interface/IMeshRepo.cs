﻿using Adam_s_Notebook_ASP.NET_API.Model;

namespace Adam_s_Notebook_ASP.NET_API.Interface {
    public interface IMeshRepo {
        IEnumerable<Mesh> GetMeshes();
        Mesh GetMeshById(int id);
    }
}
