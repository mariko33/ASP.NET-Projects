using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SnippySystem.Models.BindingModels;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Labels;

namespace SnippySystem.Services
{
    public class LabelsServece:Service
    {
        public IEnumerable<LabelViewModel> GetLabelsList()
        {
            var labels = this.Context.Labels;
            IEnumerable<LabelViewModel> model = Mapper.Map<IEnumerable<Label>, IEnumerable<LabelViewModel>>(labels);
            return model;

        }

        

        public void AddLabel(AddLabelBindingModel label)
        {
            Label labelEntity=new Label();
            labelEntity.Text = label.Text;
            this.Context.Labels.Add(labelEntity);
            this.Context.SaveChanges();
        }

        public LabelViewModel FindLabelById(int id)
        {
            Label label = this.FindLabel(id);
            LabelViewModel labelVm = Mapper.Map<Label, LabelViewModel>(label);
            return labelVm;
        }

        public void EditLabel(EditLabelBindingModel label)
        {
            Label targetLabel = this.FindLabel(label.Id);
            if (targetLabel == null)
            {
                throw new NullReferenceException("The Label is not found");
            }
            targetLabel.Text = label.Text;
            this.Context.SaveChanges();
        }

        private Label FindLabel(int id)
        {
            Label targetLabel = this.Context.Labels.FirstOrDefault(l => l.Id == id);
            return targetLabel;
        }

        public void DeleteLabe(int id)
        {
            Label targetLabel = this.FindLabel(id);

            if (targetLabel == null)
            {
                throw new NullReferenceException("The Label is not found");
            }

            this.Context.Labels.Remove(targetLabel);
            this.Context.SaveChanges();
        }
    }
}