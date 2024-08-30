using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Agendamentos;
public partial class CreateAgendamentoPage : ComponentBase
{
    [Inject]
    private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

    [Inject]
    private IMedicoRepository MedicoRepository { get; set; } = null!;

    [Inject]
    private IPacienteRepository PacienteRepository { get; set; } = null;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null;

    [Inject]
    private ISnackbar SnackBar { get; set; } = null!;

    public AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();

    public List<Medico> Medicos { get; set; } = new List<Medico>();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public TimeSpan? time { get; set; } = new TimeSpan(09,00,00);
    public DateTime? date { get; set; } = DateTime.Now.Date;
    public DateTime? MinDate { get; set; } = DateTime.Now.Date;


    public async Task OnValidSubmitAsync(EditContext editeContext)
    {
        try
        {
            if (editeContext.Model is AgendamentoInputModel model)
            {
                var agendamento = new Agendamento
                {
                    Observacao = model.Observacao,
                    PacienteId = model.PacienteId,
                    MedicoId = model.MedicoId,
                    HoraConsulta = time!.Value,
                    DataConsulta = date!.Value,
                };

                await AgendamentoRepository.AddAsync(agendamento);

                SnackBar.Add("Agendamento realizado com sucesso!", Severity.Success);
                NavigationManager.NavigateTo("/agendamentos");
            }
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        Medicos = await MedicoRepository.GetAllAsync();
        Pacientes = await PacienteRepository.GetAllAsync();
    }


}
