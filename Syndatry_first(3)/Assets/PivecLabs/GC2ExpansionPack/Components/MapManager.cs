namespace PivecLabs.GameCreator.VisualScripting
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using UnityEngine.Video;
    using System.Linq;



    public class MapManager : MonoBehaviour
    {
		public bool showMini = false;
		public bool showFull = false;
		public bool hideMini = false;
		public bool hideFull = false;
		public bool showCompass = false;
		public bool hideCompass = false;

		public bool lockFull = false;
		public bool unlockFull = false;

        public bool miniMapshowing;
        public bool fullMapshowing;
	    public bool compassshowing;
		[SerializeField] public GameObject Compasscanvas;
	    private bool CompassActive = false;
		[SerializeField] public RawImage CompassImage;
		[SerializeField] public Text CompassDirectionText;

		[SerializeField] public GameObject mapPanel;
		[SerializeField] public GameObject compassPanel;

		[SerializeField] public GameObject mapCanvas;
		[SerializeField] public GameObject rawImage;
		public GameObject player;

        public bool rotating = false;

	    [Range(1, 1500)]
	    public float cameraSizeM = 20f;
	    [Range(1, 1500)]
	    public float cameraSizeF = 20f;
	    [Range(1,100)]
	    private float cameraDistanceM = 30f;
	    [Range(1,60)]
	    private float cameraDistanceF = 30f;
	    [Range(1,60)]
	    public float planedistance = 10f;


		public int compassPosition = 1;
		public float cmwidth;
		public float cmoffsety = 10;

        public int mapPosition = 1;

		public float mmwidth;
		public float mmoffsetx = 10;
		public float mmoffsety = 10;
        private RectTransform m_RectTransform;
		public float resizeamount;
		public float resizeamount_original;
		public bool resized = false;
		private RectTransform c_RectTransform;

		public bool usePlayer = true;


	    public bool lockMap;
	    public bool centerMap;

	    public GameObject mapCenter;

        public bool zoomMap;
        public bool dragMap;
        [Range(0, 2)]
        public int dragbutton = 0;
        [Range(1, 10)]
	    public int dragspeed = 1;
	    [Range(1f, 20f)]
	    public float zoomSensitivity = 5.0f;


        RenderTexture renderTexture;
        RectTransform rt;
        RawImage img;
        private Camera targetCamera;

	    public LayerMask cullingMaskmm = ~0;
	    public bool occlusionCullingmm = true;
	    public LayerMask cullingMaskfm = ~0;
	    public bool occlusionCullingfm;
	    public int markerLayer;
		public int renderFrequency = 1;


		void Start()
        {
			mapCanvas.SetActive(false);
			Compasscanvas.SetActive(false);
			mapCanvas.GetComponent<CanvasGroup>().alpha = 1.0f;
			m_RectTransform = mapPanel.GetComponent<RectTransform>();
			c_RectTransform = compassPanel.GetComponent<RectTransform>();


		}

		void Update()
		{
			if (showMini == true)
			{
				mapCanvas.SetActive(true);
				ShowMiniMap();
							
				showMini = false;
				showFull = false;
				miniMapshowing = true;
			}


			if (showFull == true)
			{
				mapCanvas.SetActive(false);
				ShowFullScreenMap();
							
				showFull = false;
				showMini = false;
				fullMapshowing = true;
			}

			if (showCompass == true)
			{
				Compasscanvas.SetActive(true);
				CompassActive = true;
				CompassPosition();
				showCompass = false;
			}

			if (hideMini == true)
			{
				ShowNone();
				hideMini = false;
				hideFull = false;
				miniMapshowing = false;
			}

			if (hideFull == true)
			{
				ShowNone();
				hideFull = false;
				hideMini = false;
				fullMapshowing = false;
			}

			if (hideCompass == true)
			{
				Compasscanvas.SetActive(false);
				CompassActive = false;

				hideCompass = false;
			}

			if ((fullMapshowing == true) && (lockFull == true))
            {
				GameObject go = GameObject.Find("MiniMapCamera");
				go.transform.parent = null;
				lockMap = true;
				lockFull = false;
            }

			if ((fullMapshowing == true) && (unlockFull == true))
			{
				GameObject go = GameObject.Find("MiniMapCamera");
				go.transform.parent = player.transform;
				lockMap = false;
				unlockFull = false;
			}

			if ((fullMapshowing == true) && (dragMap == true) && (lockMap == true))
			{
				GameObject go = GameObject.Find("MiniMapCamera");

				if (Input.GetMouseButton(dragbutton))
				{
					go.GetComponent<Camera>().transform.position -= new Vector3(Input.GetAxis("Mouse X") * dragspeed, 0, Input.GetAxis("Mouse Y") * dragspeed);
				}
			}

			if ((fullMapshowing == true) && (zoomMap == true))
			{
				GameObject go = GameObject.Find("MiniMapCamera");
				go.GetComponent<Camera>().orthographicSize += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
			}


			if(miniMapshowing == true)
            {
				if (targetCamera != null)
				{
					if (rotating == true)
					{
						Vector3 frameAngle = new Vector3(targetCamera.transform.eulerAngles.x, player.transform.eulerAngles.y, targetCamera.transform.eulerAngles.z);
						targetCamera.transform.eulerAngles = frameAngle;
					}
					


					if (Time.frameCount % renderFrequency == 0)
					{
						targetCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraDistanceM, player.transform.position.z);

						targetCamera.Render();
					}


				}

			}
			

	        if (CompassActive)
	        {

		        Vector3 forward = player.transform.forward;
		        forward.y = 0;
		        CompassImage.uvRect = new Rect(player.transform.localEulerAngles.y / 360, 0, 1, 1);
		        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
		        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));
		        int displayangle;
		        displayangle = Mathf.RoundToInt(headingAngle);

		        switch (displayangle)
		        {
		        case 0:			
			        CompassDirectionText.text = "N";
			        break;
		        case 360:
			        CompassDirectionText.text = "N";
			        break;
		        case 45:
			        CompassDirectionText.text = "NE";
			        break;
		        case 90:
			        CompassDirectionText.text = "E";
			        break;
		        case 130:
			        CompassDirectionText.text = "SE";
			        break;
		        case 180:
			        CompassDirectionText.text = "S";
			        break;
		        case 225:
			        CompassDirectionText.text = "SW";
			        break;
		        case 270:
			        CompassDirectionText.text = "W";
			        break;
		        default:
			        CompassDirectionText.text = headingAngle.ToString ();
			        break;
		        }
	    		
	        }

        }

		void ShowNone()
		{

			GameObject go = GameObject.Find("MiniMapCamera");
			if (go)
			{

				img = null;
				targetCamera = null;
				renderTexture = null;
				Destroy(go.gameObject);
				mapCanvas.SetActive(false);

			}

		}
			void ShowMiniMap()
		{

            GameObject go = GameObject.Find("MiniMapCamera");
            if (go)
            {

                img = null;
                targetCamera = null;
                renderTexture = null;
                Destroy(go.gameObject);

            }



			if (renderTexture == null)
            {
                rt = (RectTransform)rawImage.transform;
                renderTexture = new RenderTexture((int)rt.rect.width, (int)rt.rect.height, 32);
                renderTexture.Create();

            }

            if (img == null)
            {

                img = rawImage.gameObject.GetComponent<RawImage>();
                img.texture = renderTexture;

            }

			if (targetCamera == null)
            {
				player = GameObject.Find("Player");
				GameObject cameraMinimap = new GameObject();
                targetCamera = cameraMinimap.AddComponent<Camera>();
				targetCamera.name = "MiniMapCamera";
				targetCamera.cullingMask = this.cullingMaskmm;
				targetCamera.useOcclusionCulling = occlusionCullingmm;

                targetCamera.enabled = true;
                targetCamera.allowHDR = false;
                targetCamera.targetTexture = renderTexture;
                targetCamera.orthographic = true;
				targetCamera.orthographicSize = cameraSizeM;


				targetCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraDistanceM, player.transform.position.z);
                targetCamera.transform.LookAt(player.transform);
				targetCamera.transform.localRotation = Quaternion.Euler(90.0f,0.0f,0.0f);
				
			}

			mapCanvas.GetComponent<CanvasGroup>().alpha = 1.0f;


			MiniMapPosition();
	      
			 
			targetCamera.orthographicSize = cameraSizeM;

            if (rotating == false)

            {
                mapPanel.GetComponentInChildren<FrameRotate>().rotatingFrame = false;
				mapPanel.GetComponentInChildren<PointerRotate>().rotatingPointer = true;
			}
            else
           {
                mapPanel.GetComponentInChildren<FrameRotate>().rotatingFrame = true;
				mapPanel.GetComponentInChildren<PointerRotate>().rotatingPointer = false;
			}



        }

		void CompassPosition()
		{
			c_RectTransform.localScale += new Vector3(0, 0, 0);
			cmwidth = (c_RectTransform.rect.width * (0 + 1));

			switch (compassPosition)
			{
				case 1:
					c_RectTransform.anchoredPosition = new Vector3(Screen.width/2, Screen.height - (cmoffsety));
					break;
				case 2:
					c_RectTransform.anchoredPosition = new Vector3(Screen.width/2, cmoffsety);
					break;
	

			}


		}
		void MiniMapPosition()
		{

			m_RectTransform.localScale += new Vector3(0, 0, 0);

			mmwidth = m_RectTransform.rect.width;

			if (resized == true)
			{
				if (resizeamount != resizeamount_original)
                {
					m_RectTransform.localScale += new Vector3(resizeamount, resizeamount, 0);
					mmwidth = (m_RectTransform.rect.width * (resizeamount + 1));
				}
				else
				{
					m_RectTransform.localScale += new Vector3(0, 0, 0);
					mmwidth = (m_RectTransform.rect.width * (resizeamount_original + 1));
				}

				resizeamount_original = resizeamount;
			}
			else
			{
				m_RectTransform.localScale += new Vector3(0, 0, 0);
				mmwidth = (m_RectTransform.rect.width * (0 + 1));
			}


			switch (mapPosition)
			{
				case 1:
					m_RectTransform.anchoredPosition = new Vector3(mmoffsetx, mmoffsety);
					break;
				case 2:
					m_RectTransform.anchoredPosition = new Vector3(mmoffsetx, Screen.height - (mmwidth + mmoffsety));
					break;
				case 3:
					m_RectTransform.anchoredPosition = new Vector3(Screen.width - (mmwidth + mmoffsetx), Screen.height - (mmwidth + mmoffsety));
					break;
				case 4:
					m_RectTransform.anchoredPosition = new Vector3(Screen.width - (mmwidth + mmoffsetx), mmoffsety);
					break;

			}


		}

			void ShowFullScreenMap()
        {
            GameObject go = GameObject.Find("MiniMapCamera");
            if (go)
            {

                img = null;
                targetCamera = null;
                renderTexture = null;
                Destroy(go.gameObject);

            }
            if (renderTexture != null)
            {
                renderTexture.Release();


                rt = (RectTransform)rawImage.transform;
                renderTexture = new RenderTexture((int)Screen.width, (int)Screen.height, 32);
                renderTexture.Create();
            }


            if (img == null)
            {

                img = rawImage.gameObject.GetComponent<RawImage>();
                img.texture = renderTexture;

            }

            m_RectTransform = mapPanel.GetComponent<RectTransform>();
            m_RectTransform.localScale += new Vector3(0, 0, 0);
            mmwidth = m_RectTransform.rect.width;

	        mapCanvas.GetComponent<CanvasGroup>().alpha = 0.0f;
	
	
            if (targetCamera == null)
            {
				player = GameObject.Find("Player");
				GameObject cameraMinimap = new GameObject();
                if (lockMap == false)
                {
                    cameraMinimap.transform.parent = player.transform;
                }
                targetCamera = cameraMinimap.AddComponent<Camera>();
                targetCamera.enabled = true;
                targetCamera.allowHDR = false;
                targetCamera.targetTexture = renderTexture;
                targetCamera.orthographic = true;
	            targetCamera.orthographicSize = cameraSizeF;
	            targetCamera.name = "MiniMapCamera";
	            targetCamera.cullingMask = this.cullingMaskfm;
	            targetCamera.useOcclusionCulling = occlusionCullingfm;

	            targetCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + cameraDistanceF, player.transform.position.z);
	            targetCamera.transform.localRotation = Quaternion.Euler(90.0f,0.0f,0.0f);
	            targetCamera.transform.LookAt(player.transform);
	            if (centerMap == true)
	            {
		            if (mapCenter != null)
			            targetCamera.transform.position = new Vector3(mapCenter.transform.position.x, mapCenter.transform.position.y + cameraDistanceF, mapCenter.transform.position.z);
	            }

            }
           

        }


    }
}	