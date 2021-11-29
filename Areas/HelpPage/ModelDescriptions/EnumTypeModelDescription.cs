using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PdfGenerator.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            PdfGenerator = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> PdfGenerator { get; private set; }
    }
}