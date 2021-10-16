using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace HealthyLife
{
    public class UIController : MonoBehaviour
    {
        public GameObject panel;
        public Image panelImage;
        public RectTransform panelRectTransform;
        public CanvasGroup panelCanvasGroup;

        public Text titleText;

        private void Awake() {
            DOTween.Init();
        }

        private void Start() {
            YoYoLoopEffect();
        }

        [ContextMenu("scale")]
        public void ScalePanel() {
            panel.transform.DOScale(1, 1.2f)
                //outback al finalizar la interpolacion retrosede un poco para atras
                .SetEase(Ease.OutBack);
                //OutBounce al finalizar la interpolacion hace efecto de rebote
                //.SetEase(Ease.OutBounce);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("x")]
        public void ScaleXPanel() {
            panel.transform.DOScaleX(1, 1.2f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("descale")]
        public void DescalePanel() {
            panel.transform.DOScale(0, 1.2f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("fade")]
        public void FadePanel() {
            panelImage.DOFade(0, 0.8f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("fadeInCavas")]
        public void FadeInPanelCanvasGroup() {
            panelCanvasGroup.DOFade(0, 0.8f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("fadeOutCavas")]
        public void FadeOutPanelCanvasGroup() {
            panelCanvasGroup.DOFade(1, 1.5f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("desplazar")]
        public void DesplazarPanel() {
            panelRectTransform.DOAnchorPos(new Vector2(0,0), 1.5f)
                .SetEase(Ease.OutBack);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("desplazarBonuce")]
        public void DesplazarPanelBonce() {
            panelRectTransform.DOAnchorPos(new Vector2(0,0), 1.5f)
                .SetEase(Ease.OutBounce);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        [ContextMenu("desplazardevuelta")]
        public void DesplazarDeVueltaPanel() {
            panelRectTransform.DOAnchorPos(new Vector2(-2000,0), 1.5f);
            //panel.transform.DOScale(1.2f, 0.5f).SetLoops(5).SetDelay(1f);
        }

        public void YoYoLoopEffect() {
            titleText.transform.DOScale(0, 2f)
                //LoopType.Yoyo el loop hace efecto yoyo va y vuelve la interpolacion
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
