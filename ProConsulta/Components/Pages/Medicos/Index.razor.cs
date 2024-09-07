using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Repositories.Medicos;
using System;
using System.Collections.Generic;
using System.Linq;
using ProConsulta.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace ProConsulta.Components.Pages.Medicos;
public class IndexMedicoPage : ComponentBase
{
    [Inject]
    public IMedicoRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public List<Medico> Medicos { get; set; } = new List<Medico>();
    public bool HideButtons { get; set; } = false;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;

        HideButtons = !auth.User.IsInRole("Atendente");

        Medicos = await repository.GetAllAsync();
    }

    public async Task DeleteMedicoAsync(Medico medico)
    {
        try
        {
            var result = await DialogService.ShowMessageBox(
                "Atenção",
                $"Deseja excluir o Médico {medico.Nome}?",
                yesText:"Sim",
                cancelText: "Não"
                );

            if (result is true)
            {
                await repository.DeleteByIdAsync(medico.Id);
                Snackbar.Add("Médico excluído com sucesso", Severity.Success);

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
        NavigationManager.NavigateTo($"/medicos/update/{id}");
    }
}
