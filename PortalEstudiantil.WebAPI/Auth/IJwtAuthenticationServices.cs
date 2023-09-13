using PortalEstudiantil.EntidadesDeNegocio;

namespace PortalEstudiantil.WebAPI.Auth
{
    public interface IJwtAuthenticationServices
    {
        string Authenticate(Docente pDocente);

    }
}
