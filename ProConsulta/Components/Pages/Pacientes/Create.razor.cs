using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;

public class CreatePacientePage: ComponentBase
{

    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();
    public DateTime? DataNascimento { get; set; } = DateTime.Today;

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            //editContext é o objeto validado pelo formulário
            if (editContext.Model is PacienteInputModel model)
            {
                var paciente = new Paciente()
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCaracteres(),
                    Celular = model.Celular.SomenteCaracteres(),
                    Email = model.Email,
                    DataNascimento = DataNascimento.Value
                };

                await repository.AddAsync(paciente);
                Snackbar.Add("Paciente Cadastrado com Sucesso", Severity.Success);

                NavigationManager.NavigateTo("/pacientes");
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
    }

}
