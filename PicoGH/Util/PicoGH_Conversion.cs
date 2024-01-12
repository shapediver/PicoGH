using System;

namespace PicoGH
{
    public interface IPicoGH_Conversion
    {
        Rhino.Geometry.Mesh ToRhinoMesh(PicoGK.Mesh mesh);

        PicoGK.Mesh ToPicoMesh(Rhino.Geometry.Mesh mesh);
    }

    public class PicoGH_Conversion : IPicoGH_Conversion
    {
        public PicoGK.Mesh ToPicoMesh(Rhino.Geometry.Mesh mesh)
        {
            PicoGK.Mesh pMesh = new PicoGK.Mesh();

            for (int i = 0; i < mesh.Vertices.Count; i++)
            {
                var vr = mesh.Vertices[i];
                var vn = new System.Numerics.Vector3(vr.X, vr.Y, vr.Z);
                pMesh.nAddVertex(vn);
            }
            
            for (int i = 0; i < mesh.Faces.Count; i++)
            {
                Rhino.Geometry.MeshFace face = mesh.Faces[i];
                if (face.IsTriangle)
                {
                    pMesh.nAddTriangle(face.A, face.B, face.C);
                }
                else if (face.IsQuad)
                {
                    pMesh.nAddTriangle(face.A, face.B, face.C);
                    pMesh.nAddTriangle(face.A, face.C, face.D);
                }
                else
                {
                    throw new Exception("Rhino mesh face is not a triangle nor a quad?!");
                }
            }

            return pMesh;
        }

        public Rhino.Geometry.Mesh ToRhinoMesh(PicoGK.Mesh mesh)
        {
            Rhino.Geometry.Mesh rMesh = new Rhino.Geometry.Mesh();
            rMesh.Vertices.Count = mesh.nVertexCount();

            for (int i = 0; i < mesh.nVertexCount(); i++)
            {
                var vn = mesh.vecVertexAt(i);
                var vr = new Rhino.Geometry.Point3d(vn.X, vn.Y, vn.Z);
                rMesh.Vertices.SetVertex(i, vr);
            }

            for (int i = 0; i < mesh.nTriangleCount(); i++)
            {
                var tri = mesh.oTriangleAt(i);
                rMesh.Faces.AddFace(tri.A, tri.B, tri.C);
            }

            return rMesh;
        }

    }
}
