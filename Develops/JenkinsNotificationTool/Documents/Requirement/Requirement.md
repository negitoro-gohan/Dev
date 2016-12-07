# 要件
ここには、アプリケーションで実装したい機能や設定などを記載します。

## システム要件
|項目|内容|
|:---|:---|
|OS|Windows 7/8.1/10 (x64/x86)|
|言語|日本語|
|.Net Framework|4.6.1|
|ネットワーク|Jenkinsサーバー(MC-TFSERVER)に接続できること。|
|その他||

## 機能
* 特定のジョブのみ通知を受け取るようにしたい。  
JsonAPIで現在のジョブ一覧を取得できるので実現できそう。

* 実行結果が"失敗"の場合のみ通知を受け取るようにしたい。  
WebSocketで受け取った結果に実行結果が設定されているので、それで切り分けられそう。  
ただ、ジョブによっては成功時にも通知を受け取りたいこともあると思うので、  
そのあたりは設定によって切り替えられるようにしたい。  
詳細は **【ジョブ通知バルーンについて】** を参照

* 過去に通知を受け取ったデータの一覧を表示したい。   
WebSocketで受け取った履歴データを一覧で表示したい。
表示するのは、当該端末で通知を受け取ったデータだけで良さそう。


## ジョブ通知バルーンについて
* 機能  
指定したジョブから受け取った通知をPCのタスクトレイ アイコンのバルーンに表示する機能です。

* 通知する内容  
ジョブ名称  
通知を受け取った日時  
ステータス（成功 or 失敗)  
ジョブのビルドURL  

* したいこと  
通知を受け取った時点で、WebAPIを使用してビルドURLを取得する。  
通知データとビルドURLをバルーン上に表示する。
