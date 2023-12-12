namespace StairsPlugin.KompasWrapper
{
    using System;
    using System.Runtime.InteropServices;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Описывает API компаса.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект интерфейса API КОМПАС-3D.
        /// </summary>
        private KompasObject _ksObject;

        /// <summary>
        /// Указатель на интерфейс документа.
        /// </summary>
        private ksDocument3D _ksDocument3D;

        /// <summary>
        /// Указатель на интерфейс компонента.
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Указатель на интерфейс сущности.
        /// </summary>
        private ksEntity _ksEntity;

        /// <summary>
        /// Указатель на интерфейс параметров эскиза.
        /// </summary>
        private ksSketchDefinition _ksSketchDefinition;

        /// <summary>
        /// Указатель на эскиз.
        /// </summary>
        private ksDocument2D _ksDocument2D;

        /// <summary>
        /// Стиль линии.
        /// </summary>
        private const int StyleLine = 1;

        /// <summary>
        /// Строковое наименование идентификатора COM-объекта.
        /// </summary>
        private const string KOMPAS3D_PROG_ID = "KOMPAS.Application.5";

        /// <summary>
        /// Запуск КОМПАС-3D.
        /// </summary>
        public void Start()
        {
            if (!IsKompasActive(out var kompas))
            {
                if (!IsKompasOpen(out kompas))
                {
                    throw new ArgumentException("Не удалось "
                                                + "открыть КОМПАС-3D.");
                }
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            _ksObject = kompas;
        }

        /// <summary>
        /// Проверка на состояние КОМПАС-3D.
        /// </summary>
        /// <param name="kompas">Экземпляр КОМПАС-3D.</param>
        /// <returns>True, если КОМПАС-3D активный.</returns>
        private bool IsKompasActive(out KompasObject kompas)
        {
            kompas = null;

            try
            {
                kompas = (KompasObject)Marshal.
                    GetActiveObject(KOMPAS3D_PROG_ID);
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка, является ли КОМПАС-3D открытым.
        /// </summary>
        /// <param name="kompas">Экземпляр КОМПАС-3D.</param>
        /// <returns>True, если КОМПАС-3D открыт.</returns>
        private bool IsKompasOpen(out KompasObject kompas)
        {
            try
            {
                var kompasType = Type.GetTypeFromProgID(KOMPAS3D_PROG_ID);
                kompas = (KompasObject)Activator.CreateInstance(kompasType);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }

        /// <summary>
        /// Начать редактирование.
        /// </summary>
        public void BeginEdit()
        {
            _ksDocument2D = (ksDocument2D)_ksSketchDefinition.BeginEdit();
        }

        /// <summary>
        /// Закончить редактирование.
        /// </summary>
        public void EndEdit()
        {
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Запускает окно создания 3D-модели.
        /// </summary>
        public void CreateDocument3D()
        {
            _ksDocument3D = _ksObject.Document3D();
            _ksDocument3D.Create();
            _ksPart = _ksDocument3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Выбрать плоскость для эскиза.
        /// </summary>
        /// <returns>Сущность с выбранной плоскостью.</returns>
        public ksEntity CreatePlane()
        {
            var plane = (ksEntity)_ksPart.GetDefaultEntity(
                (short)Obj3dType.o3d_planeXOY);

            _ksEntity = (ksEntity)_ksPart.NewEntity(
                (short)Obj3dType.o3d_sketch);
            _ksSketchDefinition =
                (ksSketchDefinition)_ksEntity.GetDefinition();
            _ksSketchDefinition.SetPlane(plane);
            _ksEntity.Create();

            return _ksEntity;
        }

        /// <summary>
        /// Создать прямоугольник.
        /// </summary>
        /// <param name="x">Координата вершины прямоугольника в точке x</param>
        /// <param name="y">Координата вершины прямоугольника в точке y</param>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        /// <param name="angle">Угол прямоугольника.</param>
        public void CreateRectangle(double x, double y, double width, double height, double angle)
        {
            var paramRectangle = (ksRectangleParam)_ksObject.GetParamStruct(91);
            paramRectangle.x = x;
            paramRectangle.y = y;
            paramRectangle.width = width;
            paramRectangle.height = height;
            paramRectangle.ang = angle;
            paramRectangle.style = 1;

            _ksDocument2D.ksRectangle(paramRectangle, 0);
        }

        /// <summary>
        /// Сделать выдавливание.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="depth">Глубина выдавливания.</param>
        public void MakeExtrude(ksEntity sketch, double depth)
        {
            var entityExtrude =
                (ksEntity)_ksPart.NewEntity(
                    (short)Obj3dType.o3d_baseExtrusion);
            var entityExtrudeDefinition =
                (ksBaseExtrusionDefinition)entityExtrude.GetDefinition();
            entityExtrudeDefinition.SetSideParam(
                true, 0, depth, 0, false);
            entityExtrudeDefinition.SetSketch(
                sketch.GetDefinition());
            entityExtrude.Create();
        }
    }
}