using MVC.Components.Button;
using MVC.Components.Label;
using MVC.Components.Panel;
using MVC.Controllers;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Sample
{
    public class NameRandomizer
    {
        private readonly LabelView _labelView;
        private readonly ButtonView _buttonView;
        private readonly PanelView _panelView;

        public NameRandomizer()
        {
            var labelView = CreateLabelView();
            var buttonView = CreateButtonView("Rndmzr");
            var panelView = CreatePanelView();

            panelView.AddSubView(labelView);
            panelView.AddSubView(buttonView);

            _labelView = labelView;
            _buttonView = buttonView;
            _panelView = panelView;
        }

        public ICompositeView<IModel> View => _panelView;

        public void Initialize()
        {
            _buttonView.Model.OnSubmit += HandleFormSubmit;

            RefreshData();
        }

        public void Destroy()
        {
            _buttonView.Model.OnSubmit -= HandleFormSubmit;
        }

        private void HandleFormSubmit(object sender)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var task = Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject responseJson = JObject.Parse(responseBody);
                _labelView.Model.Text = $"{responseJson["results"][0]["name"]["first"]}, {responseJson["results"][0]["name"]["last"]}";
            });

            task.Wait();
        }

        private static PanelView CreatePanelView()
        {
            var panelModel = new PanelModel();
            var panelController = new NoController<PanelModel>(panelModel);
            var panelView = new PanelView(panelModel, panelController);

            return panelView;
        }

        private static ButtonView CreateButtonView(string text)
        {
            var buttonModel = new ButtonModel(text);
            var buttonController = new ButtonController(buttonModel);
            var buttonView = new ButtonView(buttonModel, buttonController);

            return buttonView;
        }

        private static LabelView CreateLabelView()
        {
            var labelModel = new LabelModel(string.Empty);
            var labelView = new LabelView(labelModel, new NoController<LabelModel>(labelModel));

            return labelView;
        }
    }
}
