﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;

namespace ProConsulta.Components.Pages.Agendamentos;
public partial class IndexAgendamentoPage : ComponentBase
{
    [Inject]
    private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    private ISnackbar SnackBar { get; set; } = null!;

    public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public bool HideButtons { get; set; } = false;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }


    public async Task DeleteAgendamento(Agendamento agendamento)
    {
        try
        {
            var result = await DialogService.ShowMessageBox(
                "Atenção",
                "Deseja Excluir este agendamento?",
                yesText: "SIM",
                cancelText: "NÃO"
                );

            if (result is true)
            {
                await AgendamentoRepository.DeleteAsync(agendamento.Id);
                SnackBar.Add("Agendamento Excluído com Sucesso!", Severity.Success);

                await OnInitializedAsync();
            }
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;
        HideButtons = !auth.User.IsInRole("Atendente");

        try
        {
            Agendamentos = await AgendamentoRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
    }
}
