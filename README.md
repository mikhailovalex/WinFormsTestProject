# WinFormsTestProject
Это тестовый проект WinForms под .NET Framework 4.8
В этом проекте находится наследник стандартной [System.Windows.Forms.Form](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form?view=netframework-4.8) - [Form1.cs](/TestProject1/Form1.cs).

Внутри этой формы находится наследник [System.Windows.Forms.ScrollableControl](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.scrollablecontrol?view=netframework-4.8) - [ItemsControl.cs](/TestProject1/ItemsControl.cs)

### ItemsControl
Это класс, представляющий контрол для отображения элементов. Он наследуется от `ScrollableControl` и имеет свойства и методы для работы с элементами и их отображением.

### Item
Класс, описывающий элемент. У элемента есть свойства, такие как цвет (`Color`) и размер (`Size`).

### ItemsControlInfo
Этот класс представляет информацию о контроле для отображения элементов. Он хранит ссылку на контрол, список информации об элементах и имеет методы для обновления информации и отрисовки элементов.

### ItemInfo
Это класс, хранящий информацию об элементе, включая его границы и сам элемент. Он используется для отображения элементов контрола.
