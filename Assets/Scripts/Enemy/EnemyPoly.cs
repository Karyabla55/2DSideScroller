using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPolly : MonoBehaviour
{
	private PolygonCollider2D polygonCollider;
	private SpriteRenderer spriteRenderer;

	void Start()
	{
		polygonCollider = GetComponent<PolygonCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (polygonCollider == null)
		{
			Debug.LogError("PolygonCollider2D eksik! L�tfen bu nesneye bir PolygonCollider2D ekleyin.");
		}

		if (spriteRenderer == null)
		{
			Debug.LogError("SpriteRenderer eksik! L�tfen bu nesneye bir SpriteRenderer ekleyin.");
		}
	}

	void LateUpdate()
	{
		if (polygonCollider != null && spriteRenderer != null)
		{
			// Sprite'�n fizik �ekil say�s�n� al
			int shapeCount = spriteRenderer.sprite.GetPhysicsShapeCount();

			// PolygonCollider'daki pathCount'u ayarla
			polygonCollider.pathCount = shapeCount;

			for (int i = 0; i < shapeCount; i++)
			{
				// Physics Shape verilerini al
				List<Vector2> path = new List<Vector2>();
				spriteRenderer.sprite.GetPhysicsShape(i, path);

				// Collider'�n path'ini ayarla
				polygonCollider.SetPath(i, path);
			}
		}
	}

}
