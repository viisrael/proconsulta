﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes;

public class IndexPage: ComponentBase
{

    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();


    public async Task DeletePaciente(Paciente paciente)
    {
        try
        {
            var result = await Dialog.ShowMessageBox(
                "Atenção",
                $"Deseja excluir o paciente {paciente.Nome}?",
                yesText: "Sim",
                cancelText: "Não"
                );

            if (result is true)
            {
                await repository.DeleteByIdAsync(paciente.Id);
                Snackbar.Add($"Paciente {paciente.Nome} excluído com Sucesso!", Severity.Success);

                await OnInitializedAsync();
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
    }

    public void GoToUpdate(int id)
    {
        NavigationManager.NavigateTo($"/pacientes/update/{id}");
    }


    protected override async Task OnInitializedAsync()
    {
        Pacientes.Clear();
        Pacientes = await repository.GetAllAsync();
    }
}
