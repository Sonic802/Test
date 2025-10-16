@echo off
echo ===========================================
echo Unity Git 初始化脚本（Windows）
echo ===========================================

if not exist ".git" (
    git init
    echo ✅ 已初始化本地 Git 仓库
) else (
    echo ⚠️ 已存在 .git 目录，跳过初始化
)

copy setup_git_unity\.gitignore .gitignore >nul
copy setup_git_unity\.gitattributes .gitattributes >nul
echo ✅ 已复制 .gitignore 与 .gitattributes

git lfs install
git lfs track "*.png" "*.jpg" "*.psd" "*.fbx" "*.wav" "*.mp3"
echo ✅ 已启用 Git LFS 追踪大文件

set UNITY_PATH="C:\Program Files\Unity\Hub\Editor\2022.3.10f1\Editor\Data\Tools\UnityYAMLMerge.exe"
git config --global merge.unityyamlmerge.name "Unity YAML Merge"
git config --global merge.unityyamlmerge.driver "%UNITY_PATH% merge -p %%O %%A %%B %%L"
echo ✅ 已注册 Unity YAML Merge 合并工具

git config --global diff.csharp.xfuncname "^[[:space:]]*(public|private|protected|internal)?[[:space:]]*(class|struct|interface|enum|void|[A-Za-z0-9_<>,\\[\\]]+)[[:space:]]+([A-Za-z0-9_]+)"
echo ✅ 已配置 C# diff 支持

echo ===========================================
echo 🎉 完成！现在你可以开始使用 Git 了。
echo ===========================================
pause
