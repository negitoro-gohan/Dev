﻿namespace JenkinsNotification.Core.ComponentModels
{
    using System;
    using Services;
    using Utility;

    /// <summary>
    /// Viewと対になる、このアプリケーション専用のViewModel クラスです。
    /// </summary>
    /// <seealso cref="ViewModelBase" />
    /// <remarks>
    /// このViewModelは、以下の機能を備えています。<para/>
    /// ・メッセージ ダイアログを表示する。
    /// </remarks>
    public abstract class ApplicationViewModelBase : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// インジェクション サービス
        /// </summary>
        private readonly IInjectionService _injectionService;

        #endregion

        #region Ctor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="injectionService">インジェクション サービス</param>
        protected ApplicationViewModelBase(IInjectionService injectionService)
        {
            //
            // デザイナー上でViewModelをバインドするために
            // デザインモード時は常にViewModel をインスタンス化できるようにする。
            //
            if (ViewUtility.IsDesignMode()) return;
            if (injectionService == null) throw new ArgumentNullException(nameof(injectionService));

            _injectionService = injectionService;
            DialogService     = _injectionService.DialogService;
            ViewService       = _injectionService.ViewService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// <see cref="ApplicationManager"/> の参照を取得します。
        /// </summary>
        protected ApplicationManager ApplicationManager => ApplicationManager.Instance;

        /// <summary>
        /// バルーン表示サービスの参照を取得します。
        /// </summary>
        protected IBalloonTipService BalloonTipService => ApplicationManager.BalloonTipService;

        /// <summary>
        /// View表示サービスを設定、取得します。
        /// </summary>
        protected IViewService ViewService { get; private set; }

        /// <summary>
        /// ダイアログ サービスを取得します。
        /// </summary>
        protected IDialogService DialogService { get; private set; }

        #endregion
    }
}