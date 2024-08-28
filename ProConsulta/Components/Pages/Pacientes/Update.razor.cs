using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProConsulta.Components.Pages.Pacientes;
public class UpdatePacientePage : ComponentBase
{

    [Parameter]
    public int PacienteId { get; set; }

    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();
    private Paciente? CurrentPaciente { get; set; }

    public DateTime? DataNascimento { get; set; } = DateTime.Today;
    public DateTime? MaxDate { get; set; } = DateTime.Today;

    protected override async Task OnInitializedAsync()
    {
        CurrentPaciente = await repository.GetByIdAsync(PacienteId);

        if(CurrentPaciente is null)
            return;

        InputModel = new PacienteInputModel()
        {
            //Id = CurrentPaciente.Id,
            Celular = CurrentPaciente.Celular,
            DataNascimento = CurrentPaciente.DataNascimento,
            Documento = CurrentPaciente.Documento,
            Email = CurrentPaciente.Email,
            Nome = CurrentPaciente.Nome,
        };

        DataNascimento = InputModel.DataNascimento;
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            //editContext é o objeto validado pelo formulário
            if (editContext.Model is PacienteInputModel model)
            {

                CurrentPaciente.Nome = model.Nome;
                CurrentPaciente.Documento = model.Documento.SomenteCaracteres();
                CurrentPaciente.Celular = model.Celular.SomenteCaracteres();
                CurrentPaciente.Email = model.Email;
                CurrentPaciente.DataNascimento = DataNascimento.Value;

                await repository.UpdateAsync(CurrentPaciente);
                Snackbar.Add($"Paciente {CurrentPaciente.Nome} Atualizado com Sucesso", Severity.Success);

                NavigationManager.NavigateTo("/pacientes");
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
    }
}
