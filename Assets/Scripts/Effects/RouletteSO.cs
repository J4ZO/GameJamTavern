using UnityEngine;


public abstract class RouletteSO : ScriptableObject, IRouletteModifier
{
    public abstract void Apply(int entity);


    public abstract void Remove();
    
}
