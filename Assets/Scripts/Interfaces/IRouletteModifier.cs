using System;
using System.Collections.Generic;
using UnityEngine;

public interface IRouletteModifier
{
    public void Apply(int entity);
    public void Remove();
}


