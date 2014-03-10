using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lemmings
{
    public class ParticleEngine
    {
        #region DataMembers
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<ParticleSystem> particles;
        private List<Texture2D> textures;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<ParticleSystem>();
            random = new Random();
        }
        #endregion Constructor

        #region Methods
        private ParticleSystem GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                   1f * (float)(random.NextDouble() * 2 - 1),
                   1f * (float)(random.NextDouble() / 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() *2 - 1);
            Color color = Color.White;

            float size = (float)random.NextDouble();
            int ttl = 5 + random.Next(30);

            return new ParticleSystem(texture, position, velocity, angle, angularVelocity, color, size, ttl);

        }


        public void Update()
        {
            int total = 5;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }

        }
        #endregion Methods
    }
}
