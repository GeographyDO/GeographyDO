//*** 			Исходный код является собственностью компании Digital Oxygen			   	  ***//
//*** Любое копирование, воспроизведение или использование данного кода, преследуется законом ***//
//*** 				    Поэтому закрывай исходничек и спи спокойно 		  			          ***//


using UnityEngine;
 
[AddComponentMenu("Rendering/SetRenderQueue")]
 
public class SetRenderQueue : MonoBehaviour {

	Material[] materials;

	[SerializeField]
	protected int[] m_queues = new int[]{3000};
 
	protected void Awake() 
	{
		materials = GetComponent<Renderer>().materials;
		for (int i = 0; i < materials.Length && i < m_queues.Length; ++i) {
			materials[i].renderQueue = m_queues[i];
		}


	}


}