using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI points;

    public int X { get; private set; }

    public int Y { get; private set; }

    public int Value { get; private set; }

    public int Points => Value == 0 ? 0 : (int)Mathf.Pow(2, Value);

    public bool IsEmpty => Value == 0;
    public bool IsMerged { get; private set; }

    public const int MaxValue = 11;

    public void SetValue(int x, int y, int value)
    {
        X = x;
        Y = y;
        Value = value;

        UpdateCell();
    }

    public void UpdateCell()
    {
        points.text = IsEmpty ? string.Empty : Points.ToString();

        points.color = Value <= 2 ? ColorList.Instance.DarkColor : ColorList.Instance.LightColor;

        image.color = ColorList.Instance.CellColors[Value];
     }

    public void IncreaseValue()
    {
        Value++;
        IsMerged = true;
        GameController.Instance.AddPoints(Points);
        UpdateCell();
    }

    public void ResetFlags()
    {
        IsMerged = false;
    }

    public void MergeWithCell(Cell otherCell)
    {
        otherCell.IncreaseValue();
        SetValue(X, Y, 0);
        UpdateCell();
    }

    public void MoveToCell(Cell target)
    {
        target.SetValue(target.X, target.Y, Value);
        SetValue(X, Y, 0);

        UpdateCell();
    }
        
}
