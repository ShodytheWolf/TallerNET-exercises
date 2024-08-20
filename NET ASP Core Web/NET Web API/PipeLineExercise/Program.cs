// See https://aka.ms/new-console-template for more information
using PipeLineExercise.Pipeline;
using PipeLineExercise.Pipeline.PipelineImpl;

IContext context = new ImageContext();

PipelineOrchestrator orchestrator = new PipelineOrchestrator(context);

IStep step1 = new ImageLoaderStep();
IStep step2 = new ColorChangerStep();
IStep step3 = new ImageSaverStep();

orchestrator.addStep(step1);
orchestrator.addStep(step2);
orchestrator.addStep(step3);

orchestrator.execute();