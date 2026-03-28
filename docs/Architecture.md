# Rubyer-WPF 架构文档

> **版本**: 2.19.14 | **许可证**: MIT | **作者**: Ensin

---

## 1. 项目概述

Rubyer-WPF 是一套现代化的 WPF 主题与控件库，提供 Material Design 风格的 UI 组件。核心库**无外部依赖**，开箱即用，支持亮色/暗色主题切换、国际化、圆角自定义等功能。

### 目标框架

| 框架 | 版本 |
|------|------|
| .NET Framework | 4.6.2 |
| .NET Core | 3.1 |
| .NET | 6.0-windows |
| .NET | 8.0-windows |
| .NET | 9.0-windows |

---

## 2. 解决方案结构

```
Rubyer.sln
├── Rubyer/                          # 核心控件库 (NuGet 包)
├── RubyerDemo/                      # 演示应用程序
├── Tools/
│   └── RemixIconCodeGenerator/      # 图标代码生成工具
├── Image/                           # README 截图
├── pack.ps1                         # NuGet 打包脚本
├── .editorconfig                    # 代码风格配置
└── Settings.XamlStyler             # XAML 格式化规则
```

---

## 3. 核心库架构 (Rubyer/)

### 3.1 目录结构

```
Rubyer/
├── Themes/                          # XAML 样式与资源字典
│   ├── Generic.xaml                 # 主资源字典（合并所有控件样式）
│   ├── Resources/                   # 基础资源
│   │   ├── Default.xaml             # 默认布局与通用样式
│   │   ├── DefaultColor.xaml        # 颜色资源总入口
│   │   ├── LightColor.xaml          # 亮色主题颜色定义
│   │   ├── DarkColor.xaml           # 暗色主题颜色定义
│   │   ├── Converter.xaml           # 通用转换器资源
│   │   └── I18N/                    # 国际化
│   │       ├── zh-CN.xaml           # 中文
│   │       └── en-US.xaml           # 英文
│   ├── Button.xaml                  # Button 样式
│   ├── TextBox.xaml                 # TextBox 样式
│   ├── ...                          # (共 64 个控件样式文件)
│   └── Window.xaml                  # Window 样式
├── Helpers/                         # 附加属性 (Attached Properties)
├── Converters/                      # 值转换器 (IValueConverter)
├── Models/                          # 数据模型
├── Enums/                           # 枚举类型
├── Commons/                         # 工具类与扩展方法
├── DataAnnotations/                 # 数据注解
├── [控件类].cs                      # 自定义控件 (根目录，共 78 个)
├── RubyerTheme.cs                   # 主题 ResourceDictionary
├── ThemeManager.cs                  # 主题管理器
└── ResourceManager.cs               # 资源管理器
```

### 3.2 架构分层

```
┌─────────────────────────────────────────────────────────┐
│                    应用层 (Application)                    │
│                 App.xaml 合并 Generic.xaml                 │
├─────────────────────────────────────────────────────────┤
│                    主题管理层 (Theme)                      │
│  RubyerTheme · ThemeManager · ResourceManager            │
├───────────────┬─────────────────┬───────────────────────┤
│   控件层       │    辅助层        │     基础层             │
│  (Controls)    │  (Helpers)      │  (Infrastructure)     │
│               │                 │                       │
│  78+ 控件类    │  20 Helper 类   │  Converters (44)      │
│  64 XAML 样式  │  附加属性        │  Commons (11)         │
│               │                 │  Enums (7)            │
│               │                 │  Models (4)           │
└───────────────┴─────────────────┴───────────────────────┘
```

---

## 4. 自定义控件清单

### 4.1 输入控件

| 控件 | 类名 | 说明 |
|------|------|------|
| 数字输入框 | `NumericBox` | 支持整数/小数、上下按钮、范围限制 |
| 颜色选择器 | `ColorPicker` | 下拉式颜色选取，支持自定义可选颜色 |
| 颜色面板 | `ColorPalette` | 完整的 HSV 颜色选择面板 |
| 日期时间选择器 | `DateTimePicker` | 同时选择日期和时间 |
| 时间选择器 | `TimePicker` | 独立的时间选择控件 |
| 时钟 | `Clock` | 可视化时钟拨盘 |
| IP 地址输入 | `IpAddressControl` | 四段式 IP 地址输入（0-255 校验） |
| 重命名器 | `Renamer` | 内联重命名输入框 |
| 表单验证 | `ValidationForm` | 聚合子控件验证状态 |

### 4.2 展示控件

| 控件 | 类名 | 说明 |
|------|------|------|
| 图标 | `Icon` | 内置 2000+ Remix Icon 图标 |
| 头像 | `Avatar` | 圆形/圆角头像显示 |
| 徽章 | `Badge` | 数字或文本角标 |
| 标签 | `Tag` | 可带链接的信息标签 |
| 卡片 | `Card` | 带圆角和阴影的内容卡片 |
| 加载动画 | `Loading` | 环形进度/加载指示器 |
| 描述列表 | `Description` / `DescriptionItem` | 键值对描述布局 |
| 轮播图 | `FlipView` / `FlipViewItem` | 支持自动播放、循环、鼠标滚轮 |
| 过渡动画 | `Transition` | 多种入场/退场动画效果 |

### 4.3 导航控件

| 控件 | 类名 | 说明 |
|------|------|------|
| 汉堡菜单 | `HamburgerMenu` | 可展开/折叠的侧边栏导航 |
| 面包屑 | `Breadcrumb` / `BreadcrumbItem` | 层级路径导航 |
| 步骤条 | `StepBar` / `StepBarItem` | 水平/垂直步骤导航 |
| 分页栏 | `PageBar` | 分页控件，支持每页条数切换 |

### 4.4 弹出/覆盖控件

| 控件 | 类名 | 说明 |
|------|------|------|
| 对话框 | `Dialog` / `DialogCard` / `DialogContainer` | 异步模态对话框 |
| 消息条 | `Message` / `MessageCard` / `MessageContainer` | 自动关闭的消息提示 |
| 通知框 | `Notification` / `NotificationCard` / `NotificationContainer` | 带标题的持久通知 |
| 消息框 | `MessageBoxR` / `MessageBoxCard` / `MessageBoxContainer` | 按钮式模态消息框 |
| 弹出气泡 | `Popover` | 支持多种触发方式的弹出内容 |
| 下拉按钮 | `DropDownButton` | 点击弹出下拉内容的按钮 |
| 遮罩层 | `ControlMask` | 控件级别的覆盖遮罩 |

### 4.5 数据展示控件

| 控件 | 类名 | 说明 |
|------|------|------|
| 树形数据表格 | `TreeDataGrid` | 层级数据 + DataGrid 列展示 |
| 树形列表视图 | `TreeListView` / `TreeListViewItem` | 带列头的树形列表 |
| DataGrid 扩展列 | `DataGridDetailToggleButtonColumn` | 行详情展开列 |
| DataGrid 选择列 | `DataGridSelectCheckBoxColumn` | 复选框选择列 |

### 4.6 布局面板

| 控件 | 类名 | 说明 |
|------|------|------|
| 环形面板 | `CircularPanel` | 子元素环形排列 |
| 垂直均分面板 | `VerticalUniformGrid` | 垂直等分网格 |
| 覆盖面板 | `OverlayPanel` | 层叠覆盖布局 |
| 虚拟化 StackPanel | `RubyerVirtualizingStackPanel` | 带虚拟化的 StackPanel |

### 4.7 窗口与基础设施

| 控件 | 类名 | 说明 |
|------|------|------|
| 主题窗口 | `RubyerWindow` | 自定义标题栏、系统按钮的 Window |
| 主题入口 | `RubyerTheme` | ResourceDictionary 子类，配置主题参数 |
| 主题管理器 | `ThemeManager` | 运行时切换主题、颜色、语言 |
| 资源管理器 | `ResourceManager` | 全局资源访问 |
| 装饰器容器 | `AdornerContainer` / `ElementAdorner` | WPF Adorner 封装 |
| 视觉宿主 | `VisualHost` | Visual 对象宿主 |

---

## 5. 辅助类 (Helpers)

所有 Helper 类通过**附加属性 (Attached Properties)** 为 WPF 原生控件和自定义控件扩展功能。

| Helper | 核心附加属性 | 适用控件 |
|--------|-------------|---------|
| `ControlHelper` | `CornerRadius`, `FocusedBrush`, `FocusedForegroundBrush`, `FocusBorderBrush` | 通用 |
| `ButtonHelper` | `ShowShadow`, `Shape`, `Loading`, `LoadingContent`, `IconType` | Button |
| `InputBoxHelper` | `PreContent`, `PostContent`, `IsClearable`, `Watermark`, `IsRound`, `SelectAllOnFocus` | TextBox, ComboBox |
| `PasswordBoxHelper` | `IsBindable`, `BindablePassword`, `ShowSwitchButton`, `ShowPassword` | PasswordBox |
| `ComboBoxHelper` | `IsMultiSelect`, `SelectedItems`, `MultiSelectSpacing` | ComboBox |
| `DataGridHelper` | 列定义、选择、加载状态等大量属性 | DataGrid |
| `ScrollViewerHelper` | `ScrollBarForeground`, `VerticalDelta`, `IsDynamicBarSize`, `ShowArrowButton` | ScrollViewer |
| `TabControlHelper` | `AddCommand`, `RemoveCommand`, `IsClearable`, `IsShowAddButton`, `EmptyView` | TabControl |
| `GridHelper` | `Columns`, `Rows`, `ColumnDefinitions`, `RowDefinitions` | Grid |
| `TreeViewHelper` | `ExpandIconType`, `RightClickToSelected`, `IsBindable`, `SelectedItem` | TreeView |
| `ExpanderHelper` | `ExpandIconType`, `ExpandIconDock` | Expander |
| `HeaderHelper` | `Background`, `Foreground`, `FontFamily`, `FontSize`, `FontWeight`, `Padding` | 带头部的控件 |
| `ItemsControlHelper` | `ItemMargin`, `ItemPadding`, `EnumValuesToItemsSource` | ItemsControl |
| `ListBoxHelper` | `IsShowLittleBar` | ListBox |
| `MenuHelper` | `IconWidth` | Menu |
| `PanelHelper` | `Spacing` | Panel |
| `ProgressBarHelper` | `Thickness`, `ShowPercent`, `PercentFormat`, `IsAnimation` | ProgressBar |
| `SliderHelper` | `GripDiameter`, `TrackThickness`, `IsSelectionRange` | Slider |
| `ToggleButtonHelper` | `CheckedContent` | ToggleButton |
| `CommandHelpers` | 事件到命令路由（内部使用） | 通用 |

---

## 6. 值转换器 (Converters)

共 **44** 个值转换器，按功能分类如下：

### 6.1 布尔转换器

| 转换器 | 说明 |
|--------|------|
| `BooleanConverter` | 通用布尔值转换 |
| `BooleanToObjectConverter` | 布尔值 → 对象 |
| `BooleanToStringConverter` | 布尔值 → 字符串 |
| `BooleanToVisibilityConverter` | 布尔值 → Visibility |
| `BooleanToBrushConverter` | 布尔值 → Brush |
| `BooleanToInverseConverter` | 布尔值取反 |
| `VisibilityToBooleanConverter` | Visibility → 布尔值 |

### 6.2 枚举转换器

| 转换器 | 说明 |
|--------|------|
| `EnumGetDescriptionConverter` | 枚举 → Description 特性文本 |
| `EnumToBooleanConverter` | 枚举值 → 布尔值 |
| `EnumToBooleanInverseConverter` | 枚举值 → 布尔值（取反） |
| `EnumToVisibilityConverter` | 枚举值 → Visibility |

### 6.3 数学/数值转换器

| 转换器 | 说明 |
|--------|------|
| `MathConverter` | 数学表达式计算 |
| `MathMultipleConverter` | 多值数学计算 |
| `HalfOfDoubleConverter` | 数值取半 |
| `GetPercentConverter` | 百分比计算 |
| `GetPrecisionValueConverter` | 精度值计算 |

### 6.4 类型转换器

| 转换器 | 说明 |
|--------|------|
| `ColorToBrushConverter` | Color → SolidColorBrush |
| `ColorToStringConverter` | Color → 十六进制字符串 |
| `DoubleToGridLengthConverter` | double → GridLength |
| `DoubleToThicknessConverter` | double → Thickness |
| `DoublesToPointConverter` | double 数组 → Point |
| `DoublesToSizeConverter` | double 数组 → Size |
| `ListViewGridViewConverter` | ListView → GridView 判断 |
| `CloneConverter` | 对象深克隆 |

### 6.5 空值/判断转换器

| 转换器 | 说明 |
|--------|------|
| `IsNullOrEmptyConverter` | 判断 null 或空 |
| `NotNullConverter` | 判断非 null |
| `NotNullOrEmptyConverter` | 判断非 null 且非空 |
| `NullToVisibilityConverter` | null → Visibility |
| `IsEqualConverter` | 值相等判断 |

### 6.6 几何/布局转换器

| 转换器 | 说明 |
|--------|------|
| `GetCanvasCentreConverter` | Canvas 中心点计算 |
| `GetArcPointConverter` | 弧形端点计算 |
| `IsLargeArcConverter` | 大弧判断 |
| `InsideCornerRadiusConverter` | 内圆角计算 |
| `GetWidthConverter` | 宽度计算 |
| `GetSliderSelectionButtonOffsetConverter` | Slider 选区偏移 |
| `TreeViewItemOffsetConverter` | TreeView 缩进偏移 |
| `TreeListViewItemFirstColumnOffsetConverter` | TreeListView 首列偏移 |
| `BadgeOffsetConverter` | 徽章位置偏移 |

### 6.7 数据/集合转换器

| 转换器 | 说明 |
|--------|------|
| `DataGridRowIndexConverter` | DataGrid 行索引 |
| `GetDataGridColumnCheckedContentConverter` | DataGrid 列选中内容 |
| `IsLastItemConverter` | 末尾项判断 |
| `ComboBoxPopupWidthConverter` | ComboBox 下拉宽度 |

### 6.8 其他转换器

| 转换器 | 说明 |
|--------|------|
| `CarouselScaleConvereter` | 轮播缩放 |
| `AutoToolTipPlacementToPlacementModeConverter` | ToolTip 定位转换 |

---

## 7. 通用工具类 (Commons)

| 类名 | 说明 |
|------|------|
| `BooleanBoxes` | 缓存 `true`/`false` 装箱对象，优化 DependencyProperty 性能 |
| `EnumExtension` | `GetDescription()` 枚举扩展方法 |
| `FrameworkElementExtension` | 可视树导航扩展方法 |
| `ObjectExtension` | `AssertCast<T>()` 安全类型转换 |
| `WindowHelper` | 获取当前活动窗口 |
| `ValidateArgument` | `NotNull()` 参数校验 |
| `EnumDescriptionConverter` | 枚举描述 TypeConverter |
| `ElementObservableCollection` | 带 UI 元素所有者的 ObservableCollection |
| `ColumnDefinitionCollectionTypeConverter` | Grid ColumnDefinition 类型转换器 |
| `RowDefinitionCollectionTypeConverter` | Grid RowDefinition 类型转换器 |
| `PageSizeCollectionConverter` | 页大小集合类型转换器 |

---

## 8. 数据模型与枚举

### 8.1 模型 (Models)

| 模型 | 属性 | 说明 |
|------|------|------|
| `ThemeColor` | `Primary`, `Light`, `Dark`, `Accent` (均为 Brush) | 主题颜色配置 |
| `IParameters` | 接口 | 参数传递接口 |
| `Parameters` | 实现类 | 参数传递实现 |
| `ValidationModel` | 验证规则和消息 | 表单验证数据模型 |

### 8.2 枚举 (Enums)

| 枚举 | 值 | 说明 |
|------|------|------|
| `ThemeMode` | `Light`, `Dark`, `System` | 主题模式 |
| `ButtonShape` | `None`, `Round`, `Circle` | 按钮形状 |
| `AvatarShape` | `Round`, `Circle` | 头像形状 |
| `PopoverPlacementMode` | `Top`, `Bottom`, `Left`, `Right` | 弹出气泡位置 |
| `PopoverTriggerMode` | `None`, `Click`, `Hover`, `Focus`, `ContextMenu` | 弹出气泡触发方式 |
| `NumericType` | `Int`, `Double` | 数字输入类型 |
| `ColumnPosition` | `Start`, ... | 树形表格列位置 |

### 8.3 数据注解

| 注解 | 说明 |
|------|------|
| `ColumnWidthAttribute` | DataGrid 列宽配置 |

---

## 9. 弹出系统 API

### 9.1 Dialog（模态对话框）

```csharp
// 显示对话框（异步等待返回值）
Task<object> Dialog.Show(object content, object parameters = null, string title = null, ...);
Task<object> Dialog.Show(string identifier, object content, ...);

// 关闭
Dialog.Close(object parameter = null);
Dialog.Close(string identifier, object parameter = null);

// 检查
bool Dialog.IsExist(string title);

// 清除所有
Dialog.Clear();
```

### 9.2 Message（消息提示）

```csharp
// 全局消息（独立窗口）
Message.InfoGlobal(object content, int millisecondTimeOut = 3000, bool isClearable = true);
Message.SuccessGlobal(...);
Message.WarningGlobal(...);
Message.ErrorGlobal(...);

// 容器内消息
Message.Info(object content, ...);
Message.Success(...);
Message.Warning(...);
Message.Error(...);
```

### 9.3 Notification（通知框）

```csharp
// 全局通知
Notification.InfoGlobal(object content, string title = "", int millisecondTimeOut = 3000, ...);
Notification.SuccessGlobal(...);
Notification.WarningGlobal(...);
Notification.ErrorGlobal(...);

// 容器内通知
Notification.Info(object content, string title = "", ...);
Notification.Success(...);
Notification.Warning(...);
Notification.Error(...);
```

### 9.4 MessageBoxR（消息框）

```csharp
// 全局消息框（阻塞）
MessageBoxResult MessageBoxR.ConfirmGlobal(string message, string title = "", ...);
MessageBoxResult MessageBoxR.InfoGlobal(string message, ...);
MessageBoxResult MessageBoxR.WarningGlobal(string message, ...);
MessageBoxResult MessageBoxR.ErrorGlobal(string message, ...);

// 容器内消息框（异步）
Task<MessageBoxResult> MessageBoxR.Confirm(string message, ...);
Task<MessageBoxResult> MessageBoxR.Info(string message, ...);
Task<MessageBoxResult> MessageBoxR.Warning(string message, ...);
Task<MessageBoxResult> MessageBoxR.Error(string message, ...);
```

---

## 10. 图标系统

Rubyer 内置了 **2000+ Remix Icon** 图标，通过 `IconType` 枚举引用：

```xml
<!-- XAML 用法 -->
<rubyer:Icon Type="HomeLine" />
<rubyer:Icon Type="SearchLine" Width="24" Height="24" />
```

```csharp
// 代码用法
var icon = new Icon { Type = IconType.HomeLine };
```

- **IconType.cs** — 枚举定义（2000+ 值）
- **IconDatas.cs** — 图标矢量数据
- **Tools/RemixIconCodeGenerator** — 图标代码自动生成工具

---

## 11. 演示应用 (RubyerDemo)

### 11.1 架构

演示应用采用 **MVVM** 模式，使用 `CommunityToolkit.Mvvm` 和 `Microsoft.Extensions.DependencyInjection`。

```
RubyerDemo/
├── Views/                     # 52 个演示页面 (.xaml)
│   ├── MainWindow.xaml        # 主窗口
│   ├── Overview.xaml          # 概览页
│   ├── About.xaml             # 关于页
│   ├── ButtonDemo.xaml        # 按钮演示
│   ├── TextBoxDemo.xaml       # 文本框演示
│   ├── ...                    # 更多控件演示
│   ├── Samples/               # 综合示例
│   │   ├── NetEaseCloudMusic.xaml  # 网易云音乐 UI
│   │   └── Wechat.xaml             # 微信 UI
│   └── Dialogs/               # 对话框示例
│       ├── Dialog1View.xaml
│       ├── Dialog2View.xaml
│       └── DonateView.xaml
├── ViewModels/                # 31 个 ViewModel
├── Models/                    # 数据模型
├── Controls/                  # 演示专用控件
├── Converter/                 # 演示专用转换器
├── Assets/                    # 图片资源
└── Themes/                    # 演示主题定制
```

### 11.2 演示页面清单

| 类别 | 演示页面 |
|------|---------|
| 基础控件 | Button, TextBox, PasswordBox, ComboBox, CheckBox, RadioButton, ToggleButton, Label, TextBlock |
| 数据展示 | ListView, ListBox, DataGrid, TreeView, TreeDataGrid, TreeListView |
| 选择输入 | ColorPicker, DatePicker, DateTimePicker, TimePicker, NumericBox, IpAddressControl |
| 导航 | Breadcrumb, StepBar, PageBar, TabControl, Menu, HamburgerMenu |
| 布局 | Grid, GroupBox, Expander, Card, CircularPanel, Description |
| 弹出消息 | Dialog, MessageBox, Message, Notification |
| 特殊控件 | Icon, Avatar, Badge/Tag, FlipView, Loading, Transition, Popover, DropDownButton, Slider, ProgressBar, Renamer |
| 综合示例 | 网易云音乐 UI、微信 UI |

### 11.3 依赖包

| 包名 | 版本 | 用途 |
|------|------|------|
| CommunityToolkit.Mvvm | 8.0.0 | MVVM 框架 |
| Microsoft.Extensions.DependencyInjection | 7.0.0 | 依赖注入 |
| Microsoft.Xaml.Behaviors.Wpf | 1.1.39 | XAML 行为 |
| ShowMeTheXAML | 2.0.0 | XAML 代码展示 |
| VirtualizingWrapPanel | 1.5.7 | 虚拟化 WrapPanel |

---

## 12. 构建与发布

### 12.1 构建

```bash
dotnet build Rubyer.sln -c Release
```

### 12.2 NuGet 打包

```powershell
# 使用 pack.ps1 脚本
.\pack.ps1

# 或手动打包
dotnet pack Rubyer/Rubyer.csproj -c Release
```

### 12.3 安装

```
Install-Package Rubyer
```

或在 NuGet 包管理器中搜索 `Rubyer`。

---

## 13. 快速上手

### 13.1 引入主题

在 `App.xaml` 中合并主资源字典：

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/Rubyer;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

或使用 `RubyerTheme` 类（支持属性配置）：

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <rubyer:RubyerTheme ThemeMode="System"
                                ControlCornerRadius="3"
                                ContainerCornerRadius="5"
                                DefaultFontSize="14"
                                CultureName="zh-CN" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 13.2 使用控件

```xml
<Window xmlns:rubyer="clr-namespace:Rubyer;assembly=Rubyer">
    <StackPanel>
        <!-- 图标按钮 -->
        <Button Content="点击"
                rubyer:ButtonHelper.IconType="HomeLine"
                rubyer:ButtonHelper.Shape="Round" />

        <!-- 数字输入 -->
        <rubyer:NumericBox Value="42" MinValue="0" MaxValue="100" />

        <!-- 带水印的输入框 -->
        <TextBox rubyer:InputBoxHelper.Watermark="请输入..."
                 rubyer:InputBoxHelper.IsClearable="True" />

        <!-- 头像 -->
        <rubyer:Avatar Source="avatar.png" Shape="Circle" />
    </StackPanel>
</Window>
```

### 13.3 运行时切换主题

```csharp
// 切换亮/暗模式
ThemeManager.SwitchThemeMode(ThemeMode.Dark);

// 切换语言
ThemeManager.SwitchCulture("en-US");

// 自定义圆角
ThemeManager.SwitchControlCornerRadius(5);
ThemeManager.SwitchContainerCornerRadius(8);

// 自定义字体大小
ThemeManager.SwitchDefaultFontSize(16);
```
