# Rubyer-WPF 主题文档

> **版本**: 2.19.14 | **许可证**: MIT | **作者**: Ensin

---

## 1. 主题系统概述

Rubyer 的主题系统基于 WPF 的 `ResourceDictionary` 机制构建，支持：

- **亮色 / 暗色 / 跟随系统** 三种主题模式
- **运行时动态切换** 主题颜色、圆角、字体大小
- **国际化** 支持中英文切换
- **自定义颜色覆盖** 可在应用层覆盖任意颜色资源

---

## 2. 主题资源架构

### 2.1 资源加载链路

```
Generic.xaml (主入口)
├── Resources/Default.xaml (基础样式与常量)
│   ├── Resources/DefaultColor.xaml (颜色总入口)
│   │   ├── Resources/LightColor.xaml (亮色颜色值)
│   │   └── Resources/DarkColor.xaml (暗色颜色值)
│   ├── Resources/Converter.xaml (XAML 转换器)
│   └── Resources/I18N/zh-CN.xaml (默认语言)
├── Button.xaml
├── TextBox.xaml
├── PasswordBox.xaml
├── ... (64 个控件样式文件)
└── Window.xaml
```

### 2.2 资源文件说明

| 文件 | 路径 | 说明 |
|------|------|------|
| `Generic.xaml` | `Themes/Generic.xaml` | 主资源字典，合并所有子资源 |
| `Default.xaml` | `Themes/Resources/Default.xaml` | 字体大小、边框、圆角、阴影效果等基础常量 |
| `DefaultColor.xaml` | `Themes/Resources/DefaultColor.xaml` | 动态颜色画笔定义（引用 Light/Dark 颜色） |
| `LightColor.xaml` | `Themes/Resources/LightColor.xaml` | 亮色模式下的所有颜色值 |
| `DarkColor.xaml` | `Themes/Resources/DarkColor.xaml` | 暗色模式下的所有颜色值 |
| `Converter.xaml` | `Themes/Resources/Converter.xaml` | 样式中使用的通用转换器实例 |
| `zh-CN.xaml` | `Themes/Resources/I18N/zh-CN.xaml` | 中文本地化字符串 |
| `en-US.xaml` | `Themes/Resources/I18N/en-US.xaml` | 英文本地化字符串 |

### 2.3 控件样式文件 (64 个)

| 文件 | 对应控件 |
|------|---------|
| `Avatar.xaml` | Avatar 头像 |
| `Badge.xaml` | Badge 徽章 |
| `Breadcrumb.xaml` | Breadcrumb 面包屑 |
| `Button.xaml` | Button 按钮 |
| `Calendar.xaml` | Calendar 日历 |
| `Card.xaml` | Card 卡片 |
| `CheckBox.xaml` | CheckBox 复选框 |
| `Clock.xaml` | Clock 时钟 |
| `ColorPalette.xaml` | ColorPalette 颜色面板 |
| `ColorPicker.xaml` | ColorPicker 颜色选择器 |
| `ComboBox.xaml` | ComboBox 下拉框 |
| `ContextMenu.xaml` | ContextMenu 右键菜单 |
| `ControlMask.xaml` | ControlMask 遮罩层 |
| `DataGrid.xaml` | DataGrid 数据表格 |
| `DatePicker.xaml` | DatePicker 日期选择器 |
| `DateTimePicker.xaml` | DateTimePicker 日期时间选择器 |
| `Description.xaml` | Description 描述列表 |
| `DialogCard.xaml` | DialogCard 对话框卡片 |
| `DialogContainer.xaml` | DialogContainer 对话框容器 |
| `DropDownButton.xaml` | DropDownButton 下拉按钮 |
| `Expander.xaml` | Expander 展开器 |
| `FlipView.xaml` | FlipView 轮播图 |
| `GroupBox.xaml` | GroupBox 分组框 |
| `HamburgerMenu.xaml` | HamburgerMenu 汉堡菜单 |
| `Icon.xaml` | Icon 图标 |
| `IpAddressControl.xaml` | IpAddressControl IP 输入 |
| `Label.xaml` | Label 标签 |
| `ListBox.xaml` | ListBox 列表框 |
| `ListView.xaml` | ListView 列表视图 |
| `Loading.xaml` | Loading 加载动画 |
| `Menu.xaml` | Menu 菜单 |
| `MessageBoxCard.xaml` | MessageBoxCard 消息框卡片 |
| `MessageBoxContainer.xaml` | MessageBoxContainer 消息框容器 |
| `MessageCard.xaml` | MessageCard 消息卡片 |
| `MessageContainer.xaml` | MessageContainer 消息容器 |
| `NotificationCard.xaml` | NotificationCard 通知卡片 |
| `NotificationContainer.xaml` | NotificationContainer 通知容器 |
| `NumericBox.xaml` | NumericBox 数字输入框 |
| `PageBar.xaml` | PageBar 分页栏 |
| `PasswordBox.xaml` | PasswordBox 密码框 |
| `Popover.xaml` | Popover 弹出气泡 |
| `ProgressBar.xaml` | ProgressBar 进度条 |
| `RadioButton.xaml` | RadioButton 单选按钮 |
| `Renamer.xaml` | Renamer 重命名器 |
| `RepeatButton.xaml` | RepeatButton 重复按钮 |
| `ScrollBar.xaml` | ScrollBar 滚动条 |
| `ScrollViewer.xaml` | ScrollViewer 滚动视图 |
| `Slider.xaml` | Slider 滑块 |
| `StatusBar.xaml` | StatusBar 状态栏 |
| `StepBar.xaml` | StepBar 步骤条 |
| `TabControl.xaml` | TabControl 选项卡 |
| `Tag.xaml` | Tag 标签 |
| `TextBlock.xaml` | TextBlock 文本块 |
| `TextBox.xaml` | TextBox 文本框 |
| `TimePicker.xaml` | TimePicker 时间选择器 |
| `ToggleButton.xaml` | ToggleButton 切换按钮 |
| `ToolBar.xaml` | ToolBar 工具栏 |
| `ToolTip.xaml` | ToolTip 提示框 |
| `Transition.xaml` | Transition 过渡动画 |
| `TreeDataGrid.xaml` | TreeDataGrid 树形表格 |
| `TreeListView.xaml` | TreeListView 树形列表 |
| `TreeView.xaml` | TreeView 树视图 |
| `Window.xaml` | Window 窗口 |

---

## 3. 颜色系统

### 3.1 颜色资源键

Rubyer 定义了 **29 个核心颜色资源键**，每个键对应一个 `SolidColorBrush`，其 `Color` 通过 `DynamicResource` 绑定到亮色或暗色的颜色值，从而实现主题切换。

#### 颜色架构示意

```
LightPrimaryColor (#2196F3)  ──┐
                                ├──→ Primary (SolidColorBrush, DynamicResource)
DarkPrimaryColor (#2196F3)   ──┘
```

切换主题时，`ThemeManager` 将 `Primary` 画笔的 `Color` 从 `LightPrimaryColor` 动态切换到 `DarkPrimaryColor`（或反向），并附带颜色动画过渡效果。

### 3.2 完整颜色表

| 资源键 | 用途 | 亮色值 | 暗色值 |
|--------|------|--------|--------|
| `DefaultForeground` | 默认前景色（文本） | `#252526` | `#E6E6E6` |
| `DefaultBackground` | 默认背景色 | `#FFFFFF` | `#424242` |
| `FloatBackground` | 浮动元素背景（弹窗等） | `#FFFFFF` | `#292929` |
| `ControlBackground` | 控件背景 | `#FFFFFF` | `#292929` |
| `ContainerBackground` | 容器背景 | `#FFFFFF` | `#292929` |
| `Primary` | 主色调 | `#2196F3` | `#2196F3` |
| `Accent` | 强调色 | `#F50057` | `#F50057` |
| `Light` | 主色调亮变体 | `#6EC6FF` | `#6EC6FF` |
| `Dark` | 主色调暗变体 | `#0069C0` | `#0069C0` |
| `Secondary` | 次要色 | `#E3E3E3` | `#424242` |
| `SecondaryForeground` | 次要前景色 | `#252526` | `#FFFFFF` |
| `Border` | 边框色 | `#9E9E9E` | `#CFCFCF` |
| `BorderLight` | 浅边框色 | `#CFCFCF` | `#616161` |
| `BorderLighter` | 更浅边框色 | `#E0E0E0` | `#424242` |
| `SeconarydText` | 次要文本色 | `#CC9E9E9E` | `#CCBDBDBD` |
| `WatermarkText` | 水印/占位文本色 | `#BB6D6D6D` | `#BBE0E0E0` |
| `Mask` | 遮罩色 | `#9E9E9E` | `#9E9E9E` |
| `MaskDark` | 深遮罩色 | `#6D6D6D` | `#606060` |
| `DialogBackground` | 对话框遮罩背景 | `#99373737` | `#88111111` |
| `HeaderBackground` | 表头/头部背景 | `#E5E5E5` | `#292929` |
| `ScrollBarBrush` | 滚动条颜色 | `#CFCFCF` | `#595959` |
| `WindowTitleBackground` | 窗口标题栏背景 | `#F7F7F7` | `#3A3A3A` |
| `StatusBarBackground` | 状态栏背景 | `#E5E5E5` | `#292929` |
| `PanelBackground` | 面板背景 | `#F0F0F0` | `#323232` |
| `WhiteForeground` | 白色前景 | `#FFFFFF` | `#FFFFFF` |
| `BlackForeground` | 黑色前景 | `#000000` | `#000000` |
| `Error` | 错误色 | `#E63935` | `#E63935` |
| `Info` | 信息色 | `#909399` | `#909399` |
| `Warning` | 警告色 | `#F57C00` | `#F57C00` |
| `Success` | 成功色 | `#43A047` | `#43A047` |
| `Question` | 询问色 | `#2196F3` | `#2196F3` |

### 3.3 阴影效果资源键

| 资源键 | 说明 |
|--------|------|
| `AllDirectionEffect` | 全方向阴影（默认级别） |
| `AllDirectionEffect2` | 全方向阴影（级别 2） |
| `AllDirectionEffect3` | 全方向阴影（级别 3） |
| `AllDirectionEffect4` | 全方向阴影（级别 4） |
| `AllDirectionEffect5` | 全方向阴影（级别 5） |
| `RightTopEffect` | 右上方阴影 |
| `LeftTopEffect` | 左上方阴影 |
| `RightBottomEffect` | 右下方阴影 |
| `LeftBottomEffect` | 左下方阴影 |
| `TopEffect` | 上方阴影 |
| `BottomEffect` | 下方阴影 |
| `LeftEffect` | 左方阴影 |
| `RightEffect` | 右方阴影 |

---

## 4. 主题模式

### 4.1 ThemeMode 枚举

```csharp
public enum ThemeMode
{
    Light = 0,    // 亮色模式
    Dark,         // 暗色模式
    System        // 跟随系统设置
}
```

### 4.2 主题切换原理

当调用 `ThemeManager.SwitchThemeMode()` 时，系统执行以下步骤：

1. **确定目标模式**：如果是 `System`，则读取 Windows 注册表的深色模式设置
2. **遍历颜色键**：对 29 个颜色资源键执行颜色动画过渡
3. **更新画笔资源**：将 `SolidColorBrush.Color` 从 `Light{Key}Color` 切换到 `Dark{Key}Color`（或反向）
4. **更新阴影效果**：切换阴影颜色（亮色用 `#969696`，暗色用 `#000000`）
5. **触发事件**：通知 `ThemeModeChanged` 订阅者

---

## 5. ThemeManager API

`ThemeManager` 是主题系统的核心静态类，提供运行时主题管理能力。

### 5.1 颜色键字典

```csharp
// 29 个颜色资源键及其描述
static Dictionary<string, string> ColorKeys;

// 13 个阴影效果资源键及其描述
static Dictionary<string, string> EffectKeys;
```

### 5.2 主题模式切换

```csharp
// 切换主题模式（Light / Dark / System）
static void SwitchThemeMode(ThemeMode mode);

// 检测 Windows 系统是否处于深色模式
static bool GetIsAppDarkMode();

// 主题模式变更事件
static ThemeModeChangedEventHandler ThemeModeChanged;
```

### 5.3 颜色管理

```csharp
// 获取指定颜色键的亮色值
static string GetLightColor(Application app, string key);

// 获取指定颜色键的暗色值
static string GetDarkColor(Application app, string key);

// 应用自定义颜色主题（从 XAML 文件加载）
static void ApplyThemeColor(string colorUrl);

// 添加自定义颜色键（扩展默认的 29 个键）
static void AddColorKeys(params string[] keys);
```

### 5.4 外观自定义

```csharp
// 切换控件圆角半径（按钮、输入框等）
static void SwitchControlCornerRadius(double cornerRadius);

// 切换容器圆角半径（卡片、面板等）
static void SwitchContainerCornerRadius(double cornerRadius);

// 切换默认字体大小
static void SwitchDefaultFontSize(double fontSize);
```

### 5.5 国际化

```csharp
// 切换界面语言
static void SwitchCulture(string cultureName);
// 支持的值: "zh-CN" (中文), "en-US" (英文)
```

---

## 6. RubyerTheme 类

`RubyerTheme` 继承自 `ResourceDictionary`，是声明式主题配置的入口。

### 6.1 属性

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `ThemeMode` | `ThemeMode` | `System` | 主题模式 |
| `ControlCornerRadius` | `double` | `3` | 控件圆角半径 |
| `ContainerCornerRadius` | `double` | `5` | 容器圆角半径 |
| `DefaultFontSize` | `double` | `14` | 默认字体大小 |
| `CultureName` | `string` | `"zh-CN"` | 语言文化名称 |

### 6.2 XAML 用法

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <rubyer:RubyerTheme ThemeMode="Light"
                                ControlCornerRadius="4"
                                ContainerCornerRadius="8"
                                DefaultFontSize="14"
                                CultureName="zh-CN" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 7. 基础样式常量

在 `Default.xaml` 中定义的基础样式参数：

### 7.1 字体与间距

| 资源键 | 类型 | 默认值 | 说明 |
|--------|------|--------|------|
| `DefaultFontSize` | `double` | `13` | 默认字体大小 |
| `TitleFontSize` | `double` | `15` | 标题字体大小 |
| `DefaultBorderThickness` | `Thickness` | `1` | 默认边框厚度 |
| `UnenableOpcity` | `double` | `0.5` | 禁用状态不透明度 |

### 7.2 圆角资源

| 资源键 | 说明 |
|--------|------|
| `AllControlCornerRadius` | 控件四角圆角 |
| `LeftControlCornerRadius` | 控件左侧圆角 |
| `RightControlCornerRadius` | 控件右侧圆角 |
| `TopControlCornerRadius` | 控件顶部圆角 |
| `BottomControlCornerRadius` | 控件底部圆角 |
| `AllContainerCornerRadius` | 容器四角圆角 |
| `LeftContainerCornerRadius` | 容器左侧圆角 |
| `RightContainerCornerRadius` | 容器右侧圆角 |
| `TopContainerCornerRadius` | 容器顶部圆角 |
| `BottomContainerCornerRadius` | 容器底部圆角 |

---

## 8. 自定义主题颜色

### 8.1 方法一：XAML 覆盖

在 `App.xaml` 的 `MergedDictionaries` **之后** 覆盖颜色资源：

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <rubyer:RubyerTheme />
        </ResourceDictionary.MergedDictionaries>

        <!-- 覆盖主色调 -->
        <Color x:Key="LightPrimaryColor">#4CAF50</Color>
        <Color x:Key="DarkPrimaryColor">#4CAF50</Color>

        <!-- 覆盖强调色 -->
        <Color x:Key="LightAccentColor">#FF5722</Color>
        <Color x:Key="DarkAccentColor">#FF5722</Color>

        <!-- 覆盖背景色 -->
        <Color x:Key="LightDefaultBackgroundColor">#FAFAFA</Color>
        <Color x:Key="DarkDefaultBackgroundColor">#303030</Color>
    </ResourceDictionary>
</Application.Resources>
```

### 8.2 方法二：外部 XAML 颜色文件

创建一个独立的颜色定义文件（如 `CustomColors.xaml`），然后在运行时加载：

```csharp
ThemeManager.ApplyThemeColor("pack://application:,,,/MyApp;component/Themes/CustomColors.xaml");
```

### 8.3 方法三：代码动态设置

```csharp
// 修改单个颜色
Application.Current.Resources["LightPrimaryColor"] = (Color)ColorConverter.ConvertFromString("#4CAF50");
Application.Current.Resources["DarkPrimaryColor"] = (Color)ColorConverter.ConvertFromString("#4CAF50");

// 重新应用主题以生效
ThemeManager.SwitchThemeMode(ThemeMode.Light);
```

### 8.4 扩展颜色键

如果需要添加自定义颜色键参与主题切换，可使用：

```csharp
// 注册自定义颜色键
ThemeManager.AddColorKeys("MyCustomBrush", "AnotherBrush");
```

注册后，切换主题时会自动查找 `Light{Key}Color` 和 `Dark{Key}Color` 并执行切换动画。

---

## 9. 国际化 (I18N)

### 9.1 支持的语言

| 文化名称 | 语言 | 文件 |
|----------|------|------|
| `zh-CN` | 简体中文 | `Themes/Resources/I18N/zh-CN.xaml` |
| `en-US` | English | `Themes/Resources/I18N/en-US.xaml` |

### 9.2 本地化资源键

| 资源键 | 中文 (zh-CN) | 英文 (en-US) |
|--------|-------------|-------------|
| `I18N_MessageBox_Ok` | 确认 | OK |
| `I18N_MessageBox_Cancel` | 取消 | Cancel |
| `I18N_MessageBox_Yes` | 是 | Yes |
| `I18N_MessageBox_No` | 否 | No |
| `I18N_DataGrid_NoData` | 暂无数据 | No Data |
| `I18N_DataGrid_LoadingContent` | 加载中 | Loading |
| `I18N_TabControl_NoItem` | 未选中项 | Unselected item |
| `I18N_PageBar_Total` | 总 | Total |
| `I18N_PageBar_Piece` | 条 | \| |
| `I18N_PageBar_PageSize` | 条/页 | /Page |
| `I18N_PageBar_NextPage` | 下一页 | Next Page |
| `I18N_PageBar_PreviousPage` | 上一页 | Previous Page |
| `I18N_PageBar_Forward5Pages` | 向前 5 页 | Forward 5 Pages |
| `I18N_PageBar_Backwards5Pages` | 向后 5 页 | Backwards 5 Pages |
| `I18N_Clock_Hour` | 时 | hour |
| `I18N_Clock_Minute` | 分 | min |
| `I18N_Clock_Second` | 秒 | s |
| `I18N_Clock_Ok` | 确认 | OK |
| `I18N_Info` | 提示 | Info |
| `I18N_Question` | 确认 | Confirm |
| `I18N_Warning` | 警告 | Warning |
| `I18N_Success` | 成功 | Success |
| `I18N_Error` | 错误 | Error |

### 9.3 切换语言

**XAML 方式**（在 App.xaml 中添加语言资源）：

```xml
<ResourceDictionary.MergedDictionaries>
    <rubyer:RubyerTheme CultureName="en-US" />
</ResourceDictionary.MergedDictionaries>
```

**代码方式**（运行时切换）：

```csharp
ThemeManager.SwitchCulture("en-US");
```

---

## 10. 过渡动画系统

`Transition` 控件提供丰富的入场/退场动画效果，广泛用于弹窗、导航切换等场景。

### 10.1 TransitionType 枚举

| 类型 | 说明 |
|------|------|
| `None` | 无动画 |
| `Fade` | 淡入淡出 |
| `FadeLeft` | 从左侧淡入 |
| `FadeRight` | 从右侧淡入 |
| `FadeUp` | 从上方淡入 |
| `FadeDown` | 从下方淡入 |
| `Zoom` | 缩放 |
| `ZoomX` | 水平缩放 |
| `ZoomY` | 垂直缩放 |
| `ZoomLeft` | 从左侧缩放 |
| `ZoomRight` | 从右侧缩放 |
| `ZoomUp` | 从上方缩放 |
| `ZoomDown` | 从下方缩放 |
| `CollapseLeft` | 从左侧收起 |
| `CollapseRight` | 从右侧收起 |
| `CollapseUp` | 从上方收起 |
| `CollapseDown` | 从下方收起 |

### 10.2 Transition 属性

| 属性 | 类型 | 说明 |
|------|------|------|
| `IsShow` | `bool` | 控制显示/隐藏 |
| `Type` | `TransitionType` | 动画类型 |
| `Duration` | `Duration` | 动画时长 |
| `Offset` | `double` | 位置偏移量 |
| `InitialScale` | `double` | 缩放动画初始缩放值 |
| `IsFade` | `bool` | 是否同时执行淡入淡出 |
| `PlayEveryTime` | `bool` | 是否每次状态变化都播放 |
| `Progress` | `double` | 动画进度（0=隐藏, 1=显示） |
| `ShowEasingFunction` | `IEasingFunction` | 显示动画缓动函数 |
| `CloseEasingFunction` | `IEasingFunction` | 关闭动画缓动函数 |

### 10.3 用法示例

```xml
<rubyer:Transition Type="FadeUp"
                   Duration="0:0:0.3"
                   IsShow="{Binding IsVisible}">
    <Border Background="{DynamicResource Primary}" Padding="20">
        <TextBlock Text="动画内容" Foreground="White" />
    </Border>
</rubyer:Transition>
```

---

## 11. RubyerWindow 主题窗口

`RubyerWindow` 是 Rubyer 提供的自定义 Window 类，集成了主题化的标题栏和系统按钮。

### 11.1 属性

| 属性 | 类型 | 说明 |
|------|------|------|
| `TitleBarContent` | `object` | 自定义标题栏内容 |
| `TitleHeight` | `double` | 标题栏高度 |
| `TitleBackground` | `Brush` | 标题栏背景色 |
| `TitleForeground` | `Brush` | 标题栏前景色 |
| `InactiveBorderBrush` | `Brush` | 非激活状态边框色 |

### 11.2 用法

```xml
<rubyer:RubyerWindow x:Class="MyApp.MainWindow"
                     xmlns:rubyer="clr-namespace:Rubyer;assembly=Rubyer"
                     TitleHeight="40"
                     TitleBackground="{DynamicResource Primary}"
                     TitleForeground="White">
    <rubyer:RubyerWindow.TitleBarContent>
        <TextBlock Text="自定义标题栏" VerticalAlignment="Center" Margin="10,0" />
    </rubyer:RubyerWindow.TitleBarContent>

    <Grid>
        <!-- 窗口内容 -->
    </Grid>
</rubyer:RubyerWindow>
```

---

## 12. 样式定制最佳实践

### 12.1 覆盖控件样式

Rubyer 的所有控件样式均通过 `ResourceDictionary` 定义，可以在应用层进行覆盖：

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <rubyer:RubyerTheme />
        </ResourceDictionary.MergedDictionaries>

        <!-- 覆盖 Button 的默认圆角 -->
        <Style TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
            <Setter Property="rubyer:ControlHelper.CornerRadius" Value="10" />
        </Style>
    </ResourceDictionary>
</Application.Resources>
```

### 12.2 使用 ControlHelper 附加属性

几乎所有 Rubyer 控件样式都支持通过 `ControlHelper` 附加属性进行自定义：

```xml
<!-- 自定义聚焦色 -->
<TextBox rubyer:ControlHelper.FocusedBrush="{DynamicResource Success}" />

<!-- 自定义圆角 -->
<Button rubyer:ControlHelper.CornerRadius="20" />

<!-- 自定义聚焦边框色 -->
<ComboBox rubyer:ControlHelper.FocusBorderBrush="{DynamicResource Accent}" />
```

### 12.3 全局圆角调整

```csharp
// 控件级圆角（按钮、输入框、复选框等）
ThemeManager.SwitchControlCornerRadius(0);    // 直角风格
ThemeManager.SwitchControlCornerRadius(5);    // 中等圆角
ThemeManager.SwitchControlCornerRadius(20);   // 大圆角（胶囊风格）

// 容器级圆角（卡片、面板、对话框等）
ThemeManager.SwitchContainerCornerRadius(0);
ThemeManager.SwitchContainerCornerRadius(10);
```

### 12.4 响应主题变化

```csharp
ThemeManager.ThemeModeChanged += (sender, args) =>
{
    // args 包含新的主题模式信息
    // 可在此处执行自定义逻辑
};
```

---

## 13. 完整集成示例

以下是一个完整的 Rubyer 主题集成示例：

### App.xaml

```xml
<Application x:Class="MyApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:rubyer="clr-namespace:Rubyer;assembly=Rubyer"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <rubyer:RubyerTheme ThemeMode="System"
                                    ControlCornerRadius="4"
                                    ContainerCornerRadius="8"
                                    DefaultFontSize="14"
                                    CultureName="zh-CN" />
            </ResourceDictionary.MergedDictionaries>

            <!-- 自定义颜色 (可选) -->
            <Color x:Key="LightPrimaryColor">#673AB7</Color>
            <Color x:Key="DarkPrimaryColor">#673AB7</Color>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

### MainWindow.xaml

```xml
<rubyer:RubyerWindow x:Class="MyApp.MainWindow"
                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     xmlns:rubyer="clr-namespace:Rubyer;assembly=Rubyer"
                     Title="My App" Height="600" Width="800">

    <!-- 对话框容器（用于在窗口内弹出对话框） -->
    <rubyer:DialogContainer>
        <!-- 消息容器（用于在窗口内弹出消息） -->
        <rubyer:MessageContainer>
            <!-- 通知容器 -->
            <rubyer:NotificationContainer>
                <Grid>
                    <StackPanel Margin="20" Spacing="10"
                                rubyer:PanelHelper.Spacing="10">

                        <!-- 主题切换按钮 -->
                        <ToggleButton Content="暗色模式"
                                      Checked="SwitchToDark"
                                      Unchecked="SwitchToLight" />

                        <!-- 使用 Rubyer 控件 -->
                        <rubyer:NumericBox Value="0" MinValue="0" MaxValue="100" />

                        <TextBox rubyer:InputBoxHelper.Watermark="搜索..."
                                 rubyer:InputBoxHelper.IsClearable="True"
                                 rubyer:InputBoxHelper.PreContent="{rubyer:Icon Type=SearchLine}" />

                        <Button Content="打开对话框"
                                rubyer:ButtonHelper.IconType="ChatLine"
                                Click="OpenDialog" />
                    </StackPanel>
                </Grid>
            </rubyer:NotificationContainer>
        </rubyer:MessageContainer>
    </rubyer:DialogContainer>
</rubyer:RubyerWindow>
```

### MainWindow.xaml.cs

```csharp
using Rubyer;

public partial class MainWindow : RubyerWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SwitchToDark(object sender, RoutedEventArgs e)
    {
        ThemeManager.SwitchThemeMode(ThemeMode.Dark);
    }

    private void SwitchToLight(object sender, RoutedEventArgs e)
    {
        ThemeManager.SwitchThemeMode(ThemeMode.Light);
    }

    private async void OpenDialog(object sender, RoutedEventArgs e)
    {
        var result = await Dialog.Show(new TextBlock { Text = "Hello Rubyer!" }, title: "对话框");
    }
}
```
