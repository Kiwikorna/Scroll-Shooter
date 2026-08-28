using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

[DisplayStringFormat("{up}/{left}/{down}/{right}")] // This results in WASD.
[DisplayName("Up/Down/Left/Right Composite")]
public class HandlerButttanLastPress : InputBindingComposite<Vector2>
{
    [InputControl(layout = "Axis")] public int up;
    [InputControl(layout = "Axis")] public int down;
    [InputControl(layout = "Axis")] public int left;
    [InputControl(layout = "Axis")] public int right;

    private float _prevUpPress = 0f;
    private float _prevDownPress = 0f;
    private float _prevLeftPress = 0f;
    private float _prevRightPress = 0f;

    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
        float upPress = context.ReadValue<float>(up);
        float downPress = -context.ReadValue<float>(down);
        float rightPress = context.ReadValue<float>(right);
        float leftPress = -context.ReadValue<float>(left);
        Debug.Log(downPress);
        if (rightPress > 0)
        {
            
        }
        var lastXPress = EvalutePress(leftPress,rightPress,_prevLeftPress,_prevRightPress);
        var lastYPress = EvalutePress(downPress,upPress,_prevDownPress,_prevUpPress);
        
        _prevUpPress = upPress;
        _prevDownPress = downPress;
        _prevRightPress = rightPress;
        _prevLeftPress = leftPress;
        
        var result = new Vector2(lastXPress, lastYPress);
        
        if (result.x != 0 && result.y != 0)
            result *= 0.707107f;
        
        return result;

    }

    private float EvalutePress(float negativePress, float positivePress, float previousNegativePress,
        float previousPositivePress)
    {
        var winner = 0.0f;
        if (negativePress < 0 && previousPositivePress > 0) 
            return winner = -1.0f;
        if(positivePress > 0 && previousNegativePress < 0)
            return winner = 1.0f;
        
        if(negativePress < 0)
            winner = -1.0f;
        else if(positivePress > 0)
            winner = 1.0f;
        else
        {
            winner = 0;
        }
        
        return winner;
    }
    
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoadMethod]
#endif
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Register()
    {
        InputSystem.RegisterBindingComposite<HandlerButttanLastPress>();
    }
}
