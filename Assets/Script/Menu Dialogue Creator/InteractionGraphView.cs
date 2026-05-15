using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionGraphView : GraphView
{
    public InteractionGraphView()
    {
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        GridBackground grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        AddElement(CreateDialogueNode("Start Dialogue", new Vector2(100, 100)));
    }

    private Node CreateDialogueNode(string title, Vector2 position)
    {
        Node node = new Node();
        node.title = title;

        Port inputPort = node.InstantiatePort(
            Orientation.Horizontal,
            Direction.Input,
            Port.Capacity.Multi,
            typeof(bool)
        );

        inputPort.portName = "Input";
        node.inputContainer.Add(inputPort);

        Port outputPort = node.InstantiatePort(
            Orientation.Horizontal,
            Direction.Output,
            Port.Capacity.Single,
            typeof(bool)
        );

        outputPort.portName = "Next";
        node.outputContainer.Add(outputPort);

        node.SetPosition(new Rect(position, new Vector2(200, 150)));

        node.RefreshExpandedState();
        node.RefreshPorts();

        return node;
    }
}