using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos;
public class UpdateMedicoPage : ComponentBase
{

    [Parameter]
    public int id { get; set; }

    [Inject]
    private IEspecialidadeRepository EspecialidadeRepository { get; set; } = null!;

    [Inject]
    public IMedicoRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
    public Medico? CurrentMedico { get; set; } = new Medico();
    public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (CurrentMedico is null) return;

            if (editContext.Model is MedicoInputModel model)
            {

                CurrentMedico.Id = id;
                CurrentMedico.Nome = model.Nome;
                CurrentMedico.Documento = model.Documento.SomenteCaracteres();
                CurrentMedico.Celular = model.Celular.SomenteCaracteres();
                CurrentMedico.Crm = model.Crm.SomenteCaracteres();
                CurrentMedico.EspecialidadeId = model.EspecialidadeId;
                CurrentMedico.DataCadastro = model.DataCadastro;

                await repository.UpdateAsync(CurrentMedico);
                Snackbar.Add("Médico Atualizado com Sucesso!", Severity.Success);
                NavigationManager.NavigateTo("/medicos");
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        CurrentMedico = await repository.GetByIdAsync(id);

        Especialidades = await EspecialidadeRepository.GetAllAsync();

        if (CurrentMedico is null)
            return;

        InputModel = new MedicoInputModel()
        {
            Nome = CurrentMedico.Nome,
            Documento = CurrentMedico.Documento,
            Crm = CurrentMedico.Crm,
            Celular = CurrentMedico.Celular,
            EspecialidadeId = CurrentMedico.EspecialidadeId,
        };
    }
}
