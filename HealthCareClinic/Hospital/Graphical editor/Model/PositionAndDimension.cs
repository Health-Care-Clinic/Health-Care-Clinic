using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Graphical_editor.Model
{
    [Owned]
    public class PositionAndDimension 
    {
        public float X
        {
            get; 
        }
        public float Y
        {
            get; 
        }
        public float Width
        {
            get; 
        }
        public float Height
        {
            get; 
        }

        public PositionAndDimension() { }

        public PositionAndDimension(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Validate();

        }



        private void Validate()
        {
            if(this.X < 0 || this.Y < 0 || this.Width < 0 || this.Height < 0)
            {
                throw new ArgumentException("Amount can't be negative value.");
            }
        }
    }
}
