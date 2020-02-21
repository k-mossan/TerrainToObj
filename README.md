# TerrainToObj

### 概要
TerrainからobjファイルとAlphaMapを出力します。  
出力後のデータとTerrainに使ったテクスチャをTerrainMaterialに設定することで、  
Terrainの内容を再現しています。  

### 注意点
現状はobjとAlphaMapのみ再現できています。  
それ以外にも対応するべきものがあるかと思います。  
例えばHeightMapがそれにあたると思われます。  
まだ全ては把握していませんので今後改修が必要です。  

### 参考文献
TerrainからobjをExportする手法は以下のサイトから利用させていただいています。  
http://wiki.unity3d.com/index.php?title=TerrainObjExporter  
TerrainからAlphaMapをExportする手法は以下のサイトを参考にC#へ変換致しました。  
https://mattgadient.com/unity3d-a-free-script-to-convert-a-splatmap-to-a-png/  

### 使用方法

以下のExportは全てSampleSceneで行います。  

#### TerrainからobjのExport
ヒエラルキー上のTerrainを選択状態でTerrainメニューの「Export To Obj...」をクリックします。  
必要に合わせて設定を変更しExportを押下します。

#### TerrainからAlphaMapのExport
ヒエラルキー上のGameObjectにアタッチされているTestスクリプトのTerrainDataに  
Exportを行いたいTerrainアセットを割り当てます。
Playボタンを押下します。
Application.persistentDataPathにtestdata.pngが出力されます。

#### objに割り当てるマテリアルについて
Assets/Model/Materials/TerrainMaterialを対象のオブジェクトのMeshRendererに割り当てます。  
TerrainMaterialのAlphaMapにExportしたtestdata.pngを割り当てます。  
Albedo1にはTerrainのTerrainLayersに割り当てられている1枚目のpngを設定します。  
Albedo2にはTerrainのTerrainLayersに割り当てられている2枚目のpngを設定します。  
3枚目以降のpngに関しては未対応となりますが同じ要領で作れるのではないかと思っております。  
