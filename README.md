# DUE 项目部署指南

本指南将帮助你从 GitHub 克隆 DUE 项目并在本地部署运行。

## 系统要求

- **Unity**：2020.3 或更高版本
- **Git**：最新版本
- **操作系统**：Windows 10/11、macOS 或 Linux

## 克隆项目

### 方法 1：使用 Git 命令行

1. **打开终端**（Windows 上使用 PowerShell 或命令提示符，macOS/Linux 上使用终端）

2. **导航到你想要存储项目的目录**：
   ```bash
   cd path/to/your/directory
   ```

3. **克隆项目**：
   ```bash
   git clone https://github.com/hhx63com/DUE.git
   ```

4. **切换到 Main-game-library 分支**：
   ```bash
   cd DUE
   git checkout Main-game-library
   ```

### 方法 2：使用 GitHub Desktop

1. **下载并安装 GitHub Desktop**：[https://desktop.github.com/](https://desktop.github.com/)

2. **打开 GitHub Desktop** 并登录你的 GitHub 账号

3. **点击 "Clone a repository"**

4. **在 "URL" 标签页中输入**：`https://github.com/hhx63com/DUE.git`

5. **选择本地存储位置**，然后点击 "Clone"

6. **切换到 Main-game-library 分支**：
   - 在 GitHub Desktop 中，点击顶部的分支下拉菜单
   - 选择 "Main-game-library"

## 本地部署

1. **打开 Unity Hub**

2. **点击 "Add"** 按钮

3. **浏览到你克隆的项目目录**（DUE 文件夹）并选择它

4. **点击 "Open"** 打开项目

5. **等待 Unity 导入所有资源**（第一次打开可能需要一些时间）

## 运行项目

1. **在 Unity 编辑器中**，打开 "Scenes" 文件夹

2. **选择你想要运行的场景**，例如：
   - `Start.unity` - 开始场景
   - `Mune.unity` - 主菜单场景
   - `Game1.unity` - 游戏场景 1
   - `Game2.unity` - 游戏场景 2
   - `Game3.unity` - 游戏场景 3

3. **点击播放按钮**（位于 Unity 编辑器顶部）开始运行游戏

## 项目结构

```
DUE/
├── Assets/             # 游戏资源
│   ├── 2D Casual UI/     # 2D UI 资源
│   ├── Assets_SheepRun/   # 绵羊跑酷游戏资源
│   ├── Audio/            # 音频文件
│   ├── BTM_Assets/        # 宝石和物品资产
│   ├── BOXOPHOBIC/        # 资源包
│   ├── BoldPixels/        # 字体资源
│   ├── Kevin Iglesias/     # 资源包
│   ├── Material/          # 材质文件
│   ├── Neko Cat Cute Pro/ # 猫咪模型资源
│   ├── Scenes/            # 场景文件
│   ├── TextMesh Pro/      # 文本组件
│   ├── Tree_Textures/     # 树木纹理
│   ├── UnityTechnologies/ # Unity 技术资源
│   ├── Anim/              # 动画文件
│   ├── CameraController.cs     # 相机控制脚本
│   ├── ChaMove.cs              # 角色移动脚本
│   ├── AudioManager.cs         # 音频管理脚本
│   ├── BGMManager.cs           # BGM 管理脚本
│   ├── PauseOnClick.cs         # 暂停功能脚本
│   ├── ResolutionManager.cs    # 分辨率管理脚本
│   ├── RestartGame.cs          # 重新开始游戏脚本
│   ├── ShowTextOnClick.cs      # 显示文本脚本
│   └── ClickToNavigate.cs      # 点击导航脚本
├── ProjectSettings/     # 项目设置
└── README.md            # 项目说明文件
```

## 主要功能

- **鼠标拖动镜头**：按住左键拖动鼠标可以旋转镜头
- **镜头自动跟随**：松开鼠标后，镜头会平滑跟随角色朝向
- **点击3D模型跳转**：鼠标悬停在模型上会显示介绍，点击OK后跳转到对应场景
- **游戏暂停功能**：点击按钮可以暂停游戏
- **重新开始游戏**：点击按钮可以重新开始当前场景
- **显示文本功能**：点击按钮可以显示带有关闭按钮的文本
- **BGM 管理**：场景切换时 BGM 持续播放
- **分辨率适配**：自动适应不同屏幕尺寸
- **多个游戏场景**：包含多个游戏场景供选择

## 注意事项

1. **首次打开项目**：Unity 可能会提示需要安装某些包或更新，按照提示操作即可

2. **资源导入**：第一次打开项目时，Unity 需要导入所有资源，这可能需要几分钟时间，请耐心等待

3. **平台设置**：如果需要为特定平台构建项目，请在 "File > Build Settings" 中选择目标平台

4. **WebGL 构建**：如果要在 itch.io 上运行，请确保 WebGL 构建设置正确

5. **脚本错误**：如果遇到脚本错误，请检查 Unity 版本是否符合要求，或者尝试重新导入项目

6. **音频文件**：项目包含音频文件，确保你的系统音量已开启以获得完整的游戏体验

## 技术支持

如果在部署过程中遇到问题，可以：

1. 检查 Unity 控制台中的错误信息
2. 确保使用的是推荐的 Unity 版本
3. 尝试重新克隆项目并重新导入

---

**项目地址**：[https://github.com/hhx63com/DUE](https://github.com/hhx63com/DUE)
**分支**：Main-game-library
