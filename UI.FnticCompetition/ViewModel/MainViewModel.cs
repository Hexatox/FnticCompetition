using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BL.FnticCompetition.Services;
using DL.FnticCompetition.Models;

namespace UI.FnticCompetition.ViewModel;

public class MainViewModel : ViewModelBase
{
    private readonly StudentService _studentService;
    private readonly SectionService _sectionService;
    private readonly BatchService _batchService;
    private readonly GroupService _groupService;
    

    public ObservableCollection<Student> Students { get; set; }
    public ObservableCollection<Section> Sections { get; set; }
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Batch> Batches { get; set; }
    
    
    public Section SelectedSection { get; set; }
    public Batch SelectedBatch { get; set; }
    public Group SelectedGroup{ get; set; }


    public MainViewModel(StudentService studentService, SectionService sectionService , BatchService batchService, GroupService groupService)
    {
        _studentService = studentService;
        _sectionService = sectionService;
        _batchService = batchService;
        _groupService = groupService;

        Students = new ObservableCollection<Student>();
        Sections = new ObservableCollection<Section>();
        Groups = new ObservableCollection<Group>();
        Batches = new ObservableCollection<Batch>(); 
    }

  

    public async Task InitializeDataAsync()
    {
        // Batches
        
        var batches = await _batchService.GetAllBatchesAsync();
        foreach (var batch in batches)
        {
            Batches.Add(batch);
        }
        

        
        // Sections 
        //.Where(s=>s.BatchID == SelectedBatch.BatchID).ToList(); 
        var groups = (await _groupService.GetAllGroupsAsync());
        foreach (var grp in groups)
        {
            Groups.Add(grp);
        }
        
        
        //Students 
        
        
        
        // .Where(s=> s.MACAddress in  )
        var students = (await _studentService.GetStudentsAsync());
        foreach (var student in students)
        {
            Students.Add(student);
        }
    }
}